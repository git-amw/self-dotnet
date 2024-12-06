
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoCRUD.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("Name")]
        public string BookName { get; set; } = String.Empty;

        public decimal Price { get; set; }

        public string Category { get; set; } = String.Empty;

        public string Author { get; set; } = String.Empty;
    }
}