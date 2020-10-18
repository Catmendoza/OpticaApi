using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OpticaApi.Models
{
    public class Gafa
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string filtro { get; set; }

        public decimal precio { get; set; }

        public string material { get; set; }

        public string marco { get; set; }
    }
}