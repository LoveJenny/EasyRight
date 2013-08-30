using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyRight.Models
{
    [Serializable]
    public class ERRole
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Descrption { get; set; }

        public bool IsEnabled { get; set; }
    }
}