using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitorarPedidos.Model
{
    public class Compra
    {
        [BsonId]
        public string orderId { get; set; }
        public DateTime eventDate { get; set; }
        public string description { get; set; }
        public string api { get; set; }
        public Content content { get; set; }


    }

    public class Content
    {
        public string statusCode { get; set; }
    }
}
