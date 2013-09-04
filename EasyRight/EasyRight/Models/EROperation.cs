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
        [UIHint("HiddenInput")]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}