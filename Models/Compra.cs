using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OpticaApi.Models
{
    public class Compra
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string id_usuario { get; set; }

        public string id_gafa { get; set; }

        public string pago { get; set; }

    }
}