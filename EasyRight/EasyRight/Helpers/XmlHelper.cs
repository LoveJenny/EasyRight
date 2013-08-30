using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace EasyRight.Helpers
{
    public static class XmlHelper
    {
        public static string Serialize<T>(T serializeObject)
        {
            string result = "";
            using (StringWriter writer = new StringWriter())
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                formatter.Serialize(writer, serializeObject);

                result = writer.ToString();
            }

            return result;
        }

        public static T Deserialize<T>(string content)
        {
            T target_Object = default(T);

            using (StringReader reader = new StringReader(content))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                target_Object = (T)formatter.Deserialize(reader);
            }

            return target_Object;
        }
    }
}