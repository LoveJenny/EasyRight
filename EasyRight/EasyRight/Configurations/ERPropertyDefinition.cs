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
        private static Dictionary<Type, List<ERProperty>> CachedProperties = new Dictionary<Type, List<ERProperty>>();

        private static readonly string FileName = HttpContext.Current.Server.MapPath("~/bin/Configurations/ERPropertyDefinition.xml");

        public static List<ERProperty> LoadERProperties(Type type)
        {
            if (!CachedProperties.ContainsKey(type))
            {
                List<ERProperty> properties = new List<ERProperty>();

                XElement root = XElement.Load(FileName);

                foreach (var property in root.Descendants("Property"))
                {
                    if (property.Attribute("AttachedType").Value.ToUpper() == type.FullName.ToUpper())
                    {
                        string content = property.Value.Trim();

                        properties = XmlHelper.Deserialize<List<ERProperty>>(content);
                        break;
                    }
                }

                CachedProperties[type] = properties;
            }

            return CachedProperties[type];
        }
    }
}