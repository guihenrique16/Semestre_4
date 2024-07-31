using minimalAPIMongo.Domains;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace minimalAPIMongo.ViewModels
{
    public class OrderViewModel
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

        [BsonElement("status")]
        public string? Status { get; set; }

        // Lista de IDs de produtos associados ao pedido
        [BsonElement("productIds")]
        public List<string>? ProductIds { get; set; }

        [BsonIgnore]
        [JsonIgnore]
        public List<Product>? Products { get; set; }

        // ID do cliente que fez o pedido
        [BsonElement("clientId")]


        public string? ClientId { get; set; }

        [BsonIgnore]
        [JsonIgnore]
        public Client? Client { get; set; }
    }
}
