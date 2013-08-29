using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyRight.Models
{
    public class ERPropertyType
    {
        public static readonly Type String = typeof(string);
        public static readonly Type Int = typeof(int);
        public static readonly Type DateTime = typeof(DateTime);
    }

    public class ERProperty
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public ERPropertyType Type { get; set; }
    }
}