using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyRight.Models
{
    public enum ERRelationType
    { 
        RoleUser,
        RoleOperation,
    }

    [Serializable]
    public class ERRelation
    {
        [UIHint("HiddenInput")]
        public Guid Id { get; set; }

        public Guid KeyId { get; set; }
        public Guid ValueId { get; set; }

        public ERRelationType RelationType { get; set; }
    }
}