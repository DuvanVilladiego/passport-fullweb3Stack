using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Passport.Models
{
    public class Person
    {

        [BsonElement("id")]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("age")]
        public string Age { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("status")]
        public Boolean Status { get; set; } = true;

        [BsonElement("wallet")]
        public string Wallet { get; set; } = "";

        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; }

    }
}
