using MongoDB.Driver;
using MonitorarPedidos.Interface;
using MonitorarPedidos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitorarPedidos.Servicos
{
    public class CompraServico
    {
        private readonly IMongoCollection<Compra> _compras;

        public CompraServico(IMongoDbConfiguracao config)
        {
            var client = new MongoClient(config.ConnectionString);
            var database = client.GetDatabase(config.DatabaseName);

            _compras = database.GetCollection<Compra>(config.ComprasCollectionName);
        }

        public List<Compra> Get() =>
            _compras.Find(c => true).ToList();

        public Compra Get(string id) =>
            _compras.Find(c => c.orderId == id).FirstOrDefault();

        public Compra Create(Compra compra)
        {
            _compras.InsertOne(compra);
            return compra;
        }
    }
}
