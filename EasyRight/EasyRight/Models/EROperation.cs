using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyRight.Models
{
    [Serializable]
    public class EROperation
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string GroupName { get; set; }

        public bool IsSelected { get; set; }
    }
}