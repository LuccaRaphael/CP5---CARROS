using CrudMongoDB.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CrudMongoDB.Models {
    public class CarroContexto {
        private readonly IMongoDatabase _mongoDatabase;

        public CarroContexto(IOptions<ConfigDB> opcoes) {
            var mongoClient = new MongoClient(opcoes.Value.ConnectionString);

         
            _mongoDatabase = mongoClient?.GetDatabase(opcoes.Value.Database) 
                ?? throw new ArgumentNullException(nameof(mongoClient), "MongoClient não pode ser nulo.");
        }

        public IMongoCollection<Carro> Carros {
            get {
                return _mongoDatabase.GetCollection<Carro>("Carros");
            }
        }
    }
}
