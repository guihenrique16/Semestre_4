using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace minimalAPIMongo.Domains
{
    public class Order
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

        public List<Product>? Products {  get; set; }

        // ID do cliente que fez o pedido
        [BsonElement("clientId")]
        public string? ClientId { get; set; }
        public Client? Client { get; set; }  


    }
}
