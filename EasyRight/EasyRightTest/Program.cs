using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace EasyRightTest
{
    class Program
    {
        static void Main(string[] args)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            DataContractJsonSerializer dcSerializer = new DataContractJsonSerializer(typeof(User));

            User user1 = new User() { Id = Guid.NewGuid(), Name = "test1", Password = "test1", Email = "test1@ddd.com" };
            Console.WriteLine(jsSerializer.Serialize(user1));

            User user2 = new User() { Id = Guid.NewGuid(), Name = "test2", Password = "test2", Email = "test2@ddd.com" };
            user2.PropertiesBag.Test = "Hello";
            Console.WriteLine(jsSerializer.Serialize(user2));

            User user3 = new User() { Id = Guid.NewGuid(), Name = "test3", Password = "test3", Email = "test3@ddd.com" };
            user3.PropertiesData["Age"] = 18;
            user3.PropertiesData["Address"] = "dghfhfg";
            user3.PropertiesData["IsMarried"] = true;
            Console.WriteLine(jsSerializer.Serialize(user3));




            Console.ReadLine();
        }
    }


    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        private dynamic _dynamicDataDictionary;
        public dynamic PropertiesBag
        {
            get
            {
                if (this._dynamicDataDictionary == null)
                {
                    this._dynamicDataDictionary = new DynamicDictionary(() => this.PropertiesData);
                }
                return this._dynamicDataDictionary;
            }
        }

        private Dictionary<string, object> propertiesData = new Dictionary<string, object>();
        public Dictionary<string, object> PropertiesData
        {
            get { return this.propertiesData; }
        }

    }

    public class DynamicDictionary : DynamicObject
    {
        private readonly Func<Dictionary<string,object>> _DataThunk;
        public Dictionary<string,object> Data
        {
            get
            {
                return this._DataThunk();
            }
        }

        public DynamicDictionary(Func<Dictionary<string, object>> dataThunk)
        {
            this._DataThunk = dataThunk;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return this.Data.Keys;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = this.Data[binder.Name];
            return true;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            this.Data[binder.Name] = value;
            return true;
        }
    }

}
