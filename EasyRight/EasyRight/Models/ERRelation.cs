using System;
using System.Collections.Generic;
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
        public Guid Id { get; set; }

        public Guid KeyId { get; set; }
        public Guid ValueId { get; set; }

        public ERRelationType RelationType { get; set; }
    }
}