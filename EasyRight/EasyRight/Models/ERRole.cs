using NDatabase.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyRight.Models
{
    [Serializable]
    public class ERRole
    {
        [UIHint("HiddenInput")]
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Descrption { get; set; }

        public List<EROperation> GetOperations()
        {
            return ERRepositry.Instance.GetRoleOperations(this);
        }

    }
}