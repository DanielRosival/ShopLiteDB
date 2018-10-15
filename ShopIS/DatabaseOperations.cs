using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using ShopIS.ModelClasses;

namespace ShopIS
{
    public class DatabaseOperations
    {   
        public LiteCollection<T> GetCollection<T>(string name)
        {
            LiteCollection<T> collection;
            using (var db = new LiteDatabase(ConfigurationManager.AppSettings["ConnectionString"]))
            {                
                collection = db.GetCollection<T>(name);
            }
            return collection;
        }

        public void InsertObject<T>(string name, T objToInsert)
        {
            var objects = GetCollection<T>(name);
            objects.Insert(objToInsert);
        }        

        public void DeleteObject<T>(string name, int id)
        {
            var objects = GetCollection<T>(name);
            objects.Delete(new BsonValue(id));
        }

        public void UpdateObject<T>(string name, T obj)
        {
            var objects = GetCollection<T>(name);
            objects.Update(obj);
        }
    }
}
