using OpticaApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace OpticaApi.Services
{
    public class CompraService
    {
        private readonly IMongoCollection<Compra> _compra;

        public CompraService(IOpticaDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _compra = database.GetCollection<Compra>(settings.CompraCollectionName);
        }

        public List<Compra> Get() =>
            _compra.Find(compra => true).ToList();

        public Compra Get(string id) =>
            _compra.Find<Compra>(compra => compra.Id == id).FirstOrDefault();

        public Compra Create(Compra compra)
        {
            _compra.InsertOne(compra);
            return compra;
        }
    }
}