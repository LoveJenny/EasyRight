using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyRight.Models
{
    public class DefaultTemplateName
    {
        public static readonly string Boolean = "Boolean";
        public static readonly string Decimal = "Decimal";
        public static readonly string EmailAddress = "EmailAddress";
        public static readonly string HiddenInput = "HiddenInput";
        public static readonly string Html = "Html";
        public static readonly string Object = "Object";
        public static readonly string String = "String";
        public static readonly string Text = "Text";
        public static readonly string Url = "Url";
    }

    [Serializable]
    public class ERProperty
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public string TemplateName { get; set; }
    }
}