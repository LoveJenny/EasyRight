using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyRight.Models
{
    public class ERUser
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public dynamic Properties
        {
            get;
            set;
        }
    }
}