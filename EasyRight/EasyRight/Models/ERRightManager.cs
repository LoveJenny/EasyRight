using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyRight.Models
{
    public class ERRightManager
    {
        private ERRightManager()
        { }

        public static ERRightManager _instance = new ERRightManager();

        public static ERRightManager Instance
        {
            get { return _instance; }
        }

        #region User

        public void AddUser(ERUser user)
        {
        }

        public void UpdateUser(ERUser user)
        {

        }

        public void DeleteUser(ERUser user)
        {

        }

        public ERUser GetUserById(Guid id)
        {
            return null;
        }

        public List<ERUser> GetUsers()
        {
            return null;
        }

        #endregion

        #region Role

        public void AddRole(ERRole role)
        {
        }

        public void UpdateRole(ERRole role)
        {

        }

        public void DeleteRole(ERRole role)
        {

        }

        public ERRole GetRoleById(Guid id)
        {
            return null;
        }

        public List<ERRole> GetRoles()
        {
            return null;
        }

        #endregion

        #region Operations

        public void AddOperation(EROperation operation)
        {
        }

        public void UpdateOperation(EROperation operation)
        {

        }

        public void DeleteOperation(EROperation operation)
        {

        }

        public List<EROperation> GetOperations()
        {
            return null;
        }

        #endregion

        #region Relations

        /*
         *  Role has many operations
         *  Role has many users
         *  user belong to many roles
         * 
         */

        public IList<EROperation> GetRoleOperations(ERRole role)
        {
            return null;
        }

        public IList<ERUser> GetRoleUsers(ERRole role)
        {
            return null;
        }

        public IList<ERRole> GetUserRoles(ERUser user)
        {
            return null;
        }

        public IList<EROperation> GetUserOperations(ERUser user)
        {
            return null;
        }

        public void RefreshRoleOperations(ERRole role, IList<EROperation> operations)
        { }

        public void RefreshRoleUsers(ERRole role, IList<ERUser> users)
        { }

        #endregion

    }
}