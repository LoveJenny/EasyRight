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

        [UIHint("ListERProperty")]
        [System.ComponentModel.DataAnnotations.Editable(true)]
        public IList<ERProperty> Properties
        {
            get;
            set;
        }
    }
}