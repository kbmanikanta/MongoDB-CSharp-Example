using MongoDB.Bson;
using MongoDBExample.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Mappers
{
    public static class DataTableExtensions
    {
        public static IList<T> ToList<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            IList<T> result = new List<T>();

            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }

            return result;
        }

        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                property.SetValue(item, row[property.Name], null);
            }
            return item;
        }
    }

    public class PhisicalDevices
    {
        public Guid Id { get; set; }
        public Double Value { get; set; }
    }

    public class SQLServerMapper<TEntity, TDBFormat> : IMapper<TEntity, TDBFormat>
    {
        public TEntity MapToEntity(TDBFormat TDBFormatDataSet)
        {
            object datasetobject = TDBFormatDataSet;
            DataSet dataSet = (DataSet)datasetobject;

            // se aplica la extensión de datatable definida arriba
            var phisicalDevicesList = dataSet.Tables[0].ToList<PhisicalDevices>();
            
            foreach (var item in phisicalDevicesList)
            {
                Console.WriteLine(item.Id);
            }


            var entity = Activator.CreateInstance(typeof(TEntity));

            //var piArr = typeof(TEntity).GetProperties();
            //foreach (var prop in piArr)
            //{
            //    var customatt = prop.GetCustomAttributes(false);
            //    var attValue = ((CustomAttribute)customatt[0]).DBColumnName;
            //    prop.SetValue(entity, bsonDoc[attValue].AsString);
            //}
            return (TEntity)entity;
        }

        public TDBFormat MapToDbFormat(TEntity entity)
        {
            var bsonDoc = new BsonDocument();
            var piArr = entity.GetType().GetProperties();
            foreach (var prop in piArr)
            {
                var value = prop.GetValue(entity);
                var customatt = prop.GetCustomAttributes(false);
                bsonDoc.Add(((CustomAttribute)customatt[0]).DBColumnName, value.ToString());
            }
            object bsonDocObj = bsonDoc;
            return (TDBFormat)bsonDocObj;
        }
    }
}
