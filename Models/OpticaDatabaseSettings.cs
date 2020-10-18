namespace OpticaApi.Models
{
    public class OpticaDatabaseSettings : IOpticaDatabaseSettings
    {
        public string UsuarioCollectionName { get; set; }
        public string GafaCollectionName { get; set; }
        public string CompraCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IOpticaDatabaseSettings
    {
        string UsuarioCollectionName { get; set; }
        string GafaCollectionName { get; set; }
        string CompraCollectionName { get; set; }

        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}