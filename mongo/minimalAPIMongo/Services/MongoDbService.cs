using MongoDB.Driver;

namespace minimalAPIMongo.Services
{
    public class MongoDbService
    {
        /// <summary>
        /// Armazenar a configuracao da aplicacao 
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Armazena uma referencia ao mongodb
        /// </summary>
        private readonly IMongoDatabase _database;

        /// <summary>
        /// Contem a configuracao necessaria para acesso ao mongodb
        /// </summary>
        /// <param name="configuration"> objeto contendo todo a configuracao </param>
        public MongoDbService(IConfiguration configuration)
        {
            //Atribui a config recebida em _configuration
            _configuration = configuration;

            //Acessa a string de conexao
            var connectionString = _configuration.GetConnectionString("DbConnection");

            //Trasnforma a string obtida em MongoUrl
            var mongoUrl = MongoUrl.Create(connectionString);

            //Cria um Client
            var mongoClient = new MongoClient(mongoUrl);

            //Obtem a referencia ao MongoDb
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }

        /// <summary>
        /// Propiedade para acessar bd => retorna os dados em _database
        /// </summary>
        public IMongoDatabase GetDatabase => _database;
    }
}
