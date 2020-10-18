using OpticaApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace OpticaApi.Services
{
    public class UsuarioService
    {
        private readonly IMongoCollection<Usuario> _usuarios;

        public UsuarioService(IOpticaDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _usuarios = database.GetCollection<Usuario>(settings.UsuarioCollectionName);
        }

        public List<Usuario> Get() =>
            _usuarios.Find(usuario => true).ToList();

        public Usuario Get(string id) =>
            _usuarios.Find<Usuario>(usuario => usuario.Id == id).FirstOrDefault();

        public Usuario Create(Usuario usuario)
        {
            _usuarios.InsertOne(usuario);
            return usuario;
        }
    }
}