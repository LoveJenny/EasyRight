using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyRight.Models
{
    public class ERUser
    {
        public Guid Id { get; set; }

        public string UserNumber { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsEnable { get; set; }

        private Dictionary<string, object> propertiesData = new Dictionary<string, object>();
        public Dictionary<string, object> Properties
        {
            get { return this.propertiesData; }
            set { this.propertiesData = value; }
        }

    }
}