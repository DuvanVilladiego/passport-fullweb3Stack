using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Passport.Models
{
    public class PersonFilterId
    {

        [BsonElement("_id")]
        public int Id { get; set; }

    }
}
