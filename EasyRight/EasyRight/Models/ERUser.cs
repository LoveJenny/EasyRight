using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyRight.Models
{
    public class ERUser
    {
        public ERUser()
        {
            Id = Guid.NewGuid();
            Properties.Add(new ERProperty() { Name = "QQ", Value = "", TemplateName = "String" });
            Properties.Add(new ERProperty() { Name = "Sex", Value = "", TemplateName = DefaultTemplateName.Boolean });
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

        private IList<ERProperty> _properties = new List<ERProperty>();

        public IList<ERProperty> Properties
        {
            get { return _properties; }
            set { _properties = value; }
        }
    }
}