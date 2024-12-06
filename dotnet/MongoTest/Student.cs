using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoTest
{
    [BsonIgnoreExtraElements]
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("roll")]
        public int RollNumber { get; set; }

        [BsonElement("dob")]
        public DateTime DOB { get; set; }

        [BsonElement("score")]
        public int Score { get; set; }
    }
}