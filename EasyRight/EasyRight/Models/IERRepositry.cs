using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyRight.Models
{
    public interface IERRepositry
    {
        #region User

         void AddUser(ERUser user);

         void UpdateUser(ERUser user);

         void DeleteUser(ERUser user);

         ERUser GetUserById(Guid id);

         List<ERUser> GetUsers();

        #endregion

        #region Role

         void AddRole(ERRole role);
         void UpdateRole(ERRole role);
         void DeleteRole(ERRole role);

         ERRole GetRoleById(Guid id);

         List<ERRole> GetRoles();

        #endregion

        #region Operations

         void AddOperation(EROperation operation);

         void UpdateOperation(EROperation operation);

         void DeleteOperation(EROperation operation);

         List<EROperation> GetOperations();

        #endregion

        #region Relations

        /*
         *  Role has many operations
         *  Role has many users
         *  user belong to many roles
         * 
         */

         IList<EROperation> GetRoleOperations(ERRole role);

         IList<ERUser> GetRoleUsers(ERRole role);

         IList<ERRole> GetUserRoles(ERUser user);

         IList<EROperation> GetUserOperations(ERUser user);

         void RefreshRoleOperations(ERRole role, IList<EROperation> operations);

         void RefreshRoleUsers(ERRole role, IList<ERUser> users);

        #endregion

    }
}