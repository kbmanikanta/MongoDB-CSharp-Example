using MongoDB.Bson;
using MongoDBExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Mappers
{
    //public class ClientMapper : IMapper<Client, BsonDocument>
    //{
    //    public BsonDocument Mapper(Client origen)
    //    {
    //        var coll = new BsonDocument();
    //        var piArr = origen.GetType().GetProperties();
    //        foreach (var prop in piArr)
    //        {
    //            var value = prop.GetValue(origen);
    //            var customatt = prop.GetCustomAttributes(false);
    //            coll.Add(((CustomAttribute)customatt[0]).DBColumnName, value.ToString());
    //        }
    //        return coll;
    //    }

    //    public Client Mapper(BsonDocument origen)
    //    {

    //        var client = Activator.CreateInstance(typeof(Client), "", "");

    //        var piArr = typeof(Client).GetProperties();
    //        foreach (var prop in piArr)
    //        {
    //            var customatt = prop.GetCustomAttributes(false);
    //            var attValue = ((CustomAttribute)customatt[0]).DBColumnName;
    //            prop.SetValue(client, origen[attValue].AsString);
    //        }
    //        return (Client)client;
    //    }
        
        //TODO
        //public T Mapper<T>(BsonDocument origen)
        //{
        //    var client = Activator.CreateInstance(typeof(T));

        //    var piArr = typeof(T).GetProperties();
        //    foreach (var prop in piArr)
        //    {

        //        var customatt = prop.GetCustomAttributes(false);
        //        var attValue = ((CustomAttribute)customatt[0]).DBColumnName;
        //        prop.SetValue(client, origen[attValue].AsString);

        //    }
        //    return (T)client;
        //}


    //}
}
