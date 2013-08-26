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

        public string ERUserDefinition
        {
            get;
            set;
        }

        public string ERRoleDefinition
        {
            get;
            set;
        }

        public string EROptionDefinition
        {
            get;
            set;
        }


    }
}