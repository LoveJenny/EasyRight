using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyRight.Models
{
    public class ERUser
    {
        [UIHint("HiddenInput")]
        public Guid Id { get; set; }

        public string UserNumber { get; set; }

        public string Name { get; set; }

        [UIHint("EmailAddress")]
        public string Email { get; set; }

        [UIHint("Password")]
        public string Password { get; set; }

        public bool IsEnable { get; set; }

        private Dictionary<string, string> propertiesData = new Dictionary<string, string>();

        [UIHint("Collection")]
        public Dictionary<string, string> Properties
        {
            get { return this.propertiesData; }
            set { this.propertiesData = value; }
        }

        [UIHint("DatePicker")]
        public DateTime DatePicker
        {
            get;
            set;
        }
    }
}