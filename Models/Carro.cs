using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CrudMongoDB.Models {
    public class Carro {
        [BsonElement("_id")]
        public Guid CarroId { get; set; }

        public string Fabricante { get; set; } = string.Empty; 

        public string Nome { get; set; } = string.Empty; 

        public string Tipo { get; set; } = string.Empty; 
    }
}
