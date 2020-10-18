using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OpticaApi.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string cedula { get; set; }

        public string correo { get; set; }
        public string contrasenia { get; set; }
    }
}