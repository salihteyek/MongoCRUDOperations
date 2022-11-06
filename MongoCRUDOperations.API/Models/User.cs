using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoCRUDOperations.API.Models
{
    public class User
    {
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        

        [BsonElement("name")]
        public string Name { get; set; }

        
        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("phonenumbers")]
        public List<string> PhoneNumbers { get; set; }
    }
}
