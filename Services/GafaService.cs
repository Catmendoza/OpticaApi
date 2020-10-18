using OpticaApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace OpticaApi.Services
{
    public class GafaService
    {
        private readonly IMongoCollection<Gafa> _gafa;

        public GafaService(IOpticaDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _gafa = database.GetCollection<Gafa>(settings.GafaCollectionName);
        }

        public List<Gafa> Get() =>
            _gafa.Find(gafa => true).ToList();

        public Gafa Get(string id) =>
            _gafa.Find<Gafa>(gafa => gafa.Id == id).FirstOrDefault();

        public Gafa Create(Gafa gafa)
        {
            _gafa.InsertOne(gafa);
            return gafa;
        }
    }
}