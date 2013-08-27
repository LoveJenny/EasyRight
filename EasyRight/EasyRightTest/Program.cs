using NDatabase;
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
            string dbFile = "test.db";

            OdbFactory.Delete(dbFile);

            User user3 = new User() { Id = Guid.Empty, Name = "test3", Password = "test3", Email = "test3@ddd.com" };
            using (var factory = OdbFactory.Open(dbFile))
            {
                user3.PropertiesData["Age"] = 18;
                user3.PropertiesData["Address"] = "dghfhfg";
                user3.PropertiesData["IsMarried"] = true;

                factory.Store(user3);

                List<User> users = new List<User>();

                for (int i = 0; i < 10; i++)
                {
                    User tempUser = new User() { Id = Guid.NewGuid(), Name = "test" + i, Password = "test" + i, Email = i + "test@ddd.com" };
                    tempUser.PropertiesData["Age"] = i + 24;
                    tempUser.PropertiesData["Address"] = Guid.NewGuid().ToString();
                    tempUser.PropertiesData["IsMarried"] = true;

                    users.Add(tempUser);
                }

                factory.Store(users);
            }

            using (var factory = OdbFactory.Open(dbFile))
            {
                var result = factory.AsQueryable<User>().ToList();

                user3.Name = "FFFFFFF";

                var dbUser = factory.AsQueryable<User>().Where(er => er.Id == user3.Id).FirstOrDefault();
                if (dbUser != null)
                {
                    factory.Delete(dbUser);
                }

                factory.Store(user3);

                result = factory.QueryAndExecute<User>().ToList();
            }


            Console.ReadLine();
        }

        private static void JsonTest()
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

            List<User> users = new List<User>();

            for (int i = 0; i < 10; i++)
            {
                User tempUser = new User() { Id = Guid.NewGuid(), Name = "test" + i, Password = "test" + i, Email = i + "test@ddd.com" };
                tempUser.PropertiesData["Age"] = i + 24;
                tempUser.PropertiesData["Address"] = Guid.NewGuid().ToString();
                tempUser.PropertiesData["IsMarried"] = true;

                users.Add(tempUser);
            }

            string jsonUsers = jsSerializer.Serialize(users);
            Console.WriteLine(jsonUsers);

            var deserializeUsers = jsSerializer.Deserialize(jsonUsers, typeof(List<User>));
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
            set { this.propertiesData = value; }
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
