using EasyRight.Configurations;
using EasyRight.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace EasyRight.Models
{
    [Serializable]
    public class ERUser
    {
        public ERUser()
        {
            Id = Guid.NewGuid();
            Properties = ERPropertyDefinition.LoadERProperties<List<ERProperty>>(this.GetType());
        }

        [UIHint("HiddenInput")]
        public Guid Id { get; set; }

        public string UserNumber { get; set; }

        public string Name { get; set; }

        [UIHint("EmailAddress")]
        public string Email { get; set; }

        [UIHint("Password")]
        public string Password { get; set; }

        public bool IsEnable { get; set; }

        private List<ERProperty> _properties = new List<ERProperty>();

        public List<ERProperty> Properties
        {
            get { return _properties; }
            set { _properties = value; }
        }
    }
}