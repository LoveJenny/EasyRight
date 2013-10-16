using EasyRight.Configurations;
using NDatabase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EasyRight.Models
{
    public class ERRepositry : IERRepositry
    {
        private ERRepositry()
        { }

        private static ERRepositry _instance = new ERRepositry();

        public static ERRepositry Instance
        {
            get { return _instance; }
        }

        private readonly string dbFileName = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["DBFileName"].ToString());

        #region User

        public void AddUser(ERUser user)
        {
            user.Id = Guid.NewGuid();
            using (var odb = OdbFactory.Open(dbFileName))
            {
                odb.Store(user);
            }
        }

        public void UpdateUser(ERUser user)
        {
            using (var odb = OdbFactory.Open(dbFileName))
            {
                var dbUser = odb.AsQueryable<ERUser>().Where(er => er.Id == user.Id).FirstOrDefault();
                if (dbUser != null)
                {
                    odb.Delete(dbUser);
                }

                odb.Store(user);
            }
        }

        public void DeleteUser(ERUser user)
        {
            using (var odb = OdbFactory.Open(dbFileName))
            {
                var dbUser = odb.AsQueryable<ERUser>().Where(er => er.Id == user.Id).FirstOrDefault();
                if (dbUser != null)
                {
                    odb.Delete(dbUser);
                }
            }
        }

        public ERUser GetUserById(Guid id)
        {
            using (var odb = OdbFactory.Open(dbFileName))
            {
                return odb.AsQueryable<ERUser>().Where(er => er.Id == id).FirstOrDefault();
            }
        }

        public List<ERUser> GetUsers()
        {
            using (var odb = OdbFactory.Open(dbFileName))
            {
                return odb.AsQueryable<ERUser>().OrderBy(u => u.Name).ToList();
            }
        }

        #endregion

        #region Role

        public void AddRole(ERRole role)
        {
            role.Id = Guid.NewGuid();
            using (var odb = OdbFactory.Open(dbFileName))
            {
                odb.Store(role);
            }
        }

        public void UpdateRole(ERRole role)
        {
            using (var odb = OdbFactory.Open(dbFileName))
            {
                var db = odb.AsQueryable<ERRole>().Where(er => er.Id == role.Id).FirstOrDefault();
                if (db != null)
                {
                    odb.Delete(db);
                }

                odb.Store(role);
            }
        }

        public void DeleteRole(ERRole role)
        {
            using (var odb = OdbFactory.Open(dbFileName))
            {
                var db = odb.AsQueryable<ERRole>().Where(er => er.Id == role.Id).FirstOrDefault();
                if (db != null)
                {
                    odb.Delete(db);
                }
            }
        }

        public ERRole GetRoleById(Guid id)
        {
            using (var odb = OdbFactory.Open(dbFileName))
            {
                return odb.AsQueryable<ERRole>().Where(er => er.Id == id).FirstOrDefault();
            }
        }

        public List<ERRole> GetRoles()
        {
            using (var odb = OdbFactory.Open(dbFileName))
            {
                return odb.AsQueryable<ERRole>().OrderBy(r => r.Name).ToList();
            }
        }

        #endregion

        #region Operations

        /*
        public void AddOperation(EROperation operation)
        {
            operation.Id = Guid.NewGuid();
            using (var odb = OdbFactory.Open(dbFileName))
            {
                odb.Store(operation);
            }
        }

        public void UpdateOperation(EROperation operation)
        {
            using (var odb = OdbFactory.Open(dbFileName))
            {
                var db = odb.AsQueryable<EROperation>().Where(er => er.Id == operation.Id).FirstOrDefault();
                if (db != null)
                {
                    odb.Delete(db);
                }

                odb.Store(operation);
            }
        }

        public void DeleteOperation(EROperation operation)
        {
            using (var odb = OdbFactory.Open(dbFileName))
            {
                var db = odb.AsQueryable<EROperation>().Where(er => er.Id == operation.Id).FirstOrDefault();
                if (db != null)
                {
                    odb.Delete(db);
                }
            }
        }
        */
 
        public List<EROperation> GetOperations()
        {
            return ERPropertyDefinition.LoadERProperties<List<EROperation>>(typeof(EROperation));
        }

        #endregion

        #region Relations

        /*
         *  One Role has many operations
         *  One user has many roles
         */

        public List<EROperation> GetRoleOperations(ERRole role)
        {
            List<EROperation> operations = new List<EROperation>();

            using (var odb = OdbFactory.Open(dbFileName))
            {
                List<ERRelation> relations = odb.AsQueryable<ERRelation>().Where(r => r.KeyId == role.Id && r.RelationType == ERRelationType.RoleOperation).ToList();

                operations = GetOperations().Where(oper => relations.Select(r => r.ValueId).Contains(oper.Id)).ToList();
            }

            return operations;
        }

        public List<ERUser> GetRoleUsers(ERRole role)
        {
            List<ERUser> users = new List<ERUser>();

            using (var odb = OdbFactory.Open(dbFileName))
            {
                List<ERRelation> relations = odb.AsQueryable<ERRelation>().Where(r => r.KeyId == role.Id && r.RelationType == ERRelationType.RoleUser).ToList();

                users = odb.AsQueryable<ERUser>().Where(u => relations.Select(r => r.ValueId).Contains(u.Id)).ToList();
            }

            return users;
        }

        public List<ERRole> GetUserRoles(ERUser user)
        {
            List<ERRole> roles = new List<ERRole>();

            using (var odb = OdbFactory.Open(dbFileName))
            {
                List<ERRelation> relations = odb.AsQueryable<ERRelation>().Where(r => r.ValueId == user.Id && r.RelationType == ERRelationType.RoleUser).ToList();

                roles = odb.AsQueryable<ERRole>().Where(role => relations.Select(r => r.KeyId).Contains(role.Id)).ToList();
            }

            return roles;
        }

        public List<EROperation> GetUserOperations(ERUser user)
        {
            List<EROperation> operations = new List<EROperation>();
            IList<ERRole> roles = GetUserRoles(user);
            foreach (var role in roles)
            {
                var opers = GetRoleOperations(role);

                operations.AddRange(opers);
            }

            return operations;
        }

        public void RefreshRoleOperations(ERRole role, IList<EROperation> operations)
        {
            using (var odb = OdbFactory.Open(dbFileName))
            {
                List<ERRelation> relations = odb.AsQueryable<ERRelation>().ToList();

                foreach (var relation in relations)
                {
                    if (relation.KeyId == role.Id && relation.RelationType == ERRelationType.RoleOperation)
                    {
                        odb.Delete(relation);   
                    }
                }
                if (operations != null)
                {
                    List<ERRelation> newRelations = new List<ERRelation>();
                    foreach (var oper in operations)
                    {
                        newRelations.Add(new ERRelation() { Id = Guid.NewGuid(), KeyId = role.Id, ValueId = oper.Id, RelationType = ERRelationType.RoleOperation });
                    }

                    odb.Store(newRelations);
                }
            }
        }

        public void RefreshRoleUsers(ERRole role, IList<ERUser> users)
        {
            using (var odb = OdbFactory.Open(dbFileName))
            {
                List<ERRelation> relations = odb.AsQueryable<ERRelation>().ToList();

                foreach (var relation in relations)
                {
                    if (relation.KeyId == role.Id && relation.RelationType == ERRelationType.RoleUser)
                    {
                        odb.Delete(relation);
                    }
                }

                if (users != null)
                {
                    List<ERRelation> newRelations = new List<ERRelation>();
                    foreach (var user in users)
                    {
                        newRelations.Add(new ERRelation() { Id = Guid.NewGuid(), KeyId = role.Id, ValueId = user.Id, RelationType = ERRelationType.RoleUser });
                    }

                    odb.Store(newRelations);
                }
            }
        }

        public void RefreshUserRoles(ERUser user, IList<Guid> roleIds)
        {
            using (var odb = OdbFactory.Open(dbFileName))
            {
                List<ERRelation> relations = odb.AsQueryable<ERRelation>().ToList();

                foreach (var relation in relations)
                {
                    if (relation.ValueId == user.Id && relation.RelationType == ERRelationType.RoleUser)
                    {
                        odb.Delete(relation);
                    }
                }

                if (roleIds != null)
                {
                    List<ERRelation> newRelations = new List<ERRelation>();
                    foreach (var roleId in roleIds)
                    {
                        newRelations.Add(new ERRelation() { Id = Guid.NewGuid(), KeyId = roleId, ValueId = user.Id, RelationType = ERRelationType.RoleUser });
                    }

                    odb.Store(newRelations);
                }
            }
        }

        #endregion

    }
}