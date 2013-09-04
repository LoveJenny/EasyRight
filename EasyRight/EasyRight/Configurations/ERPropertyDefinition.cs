using EasyRight.Helpers;
using EasyRight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace EasyRight.Configurations
{
    public static class ERPropertyDefinition
    {
        private static Dictionary<Type, string> dicTypeContent = new Dictionary<Type, string>();

        private static readonly string FileName = HttpContext.Current.Server.MapPath("~/bin/Configurations/ERPropertyDefinition.xml");

        public static T LoadERProperties<T>(Type type)
        {
            if (!dicTypeContent.ContainsKey(type))
            {
                string content = "";

                XElement root = XElement.Load(FileName);

                foreach (var property in root.Descendants("Property"))
                {
                    if (property.Attribute("AttachedType").Value.ToUpper() == type.FullName.ToUpper())
                    {
                        content= property.Value.Trim();
                        break;
                    }
                }

                dicTypeContent[type] = content;
            }

            return XmlHelper.Deserialize<T>(dicTypeContent[type]);
        }

    }
}