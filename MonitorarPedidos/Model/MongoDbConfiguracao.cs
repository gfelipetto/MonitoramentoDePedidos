using MonitorarPedidos.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitorarPedidos.Model
{
    public class MongoDbConfiguracao : IMongoDbConfiguracao
    {
        public string ComprasCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
