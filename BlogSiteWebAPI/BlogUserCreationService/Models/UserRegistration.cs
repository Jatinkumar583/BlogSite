using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BlogUserCreationService.Models
{
    [BsonIgnoreExtraElements]
    public class UserRegistration
    {
        //[BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("userId")]
        public int UserId { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [BsonElement("lastName")]
        public string LastName { get; set; } = string.Empty;

        [BsonElement("emailId")]
        public string EmailId { get; set; } = string.Empty;

        [BsonElement("password")]
        public string Password { get; set; } = string.Empty;

        [BsonElement("loginType")]
        public string LoginType { get; set; } = string.Empty;

        [BsonElement("createdBy")]
        public int CreatedBy { get; set; }

        [BsonElement("createdOn")]
        public DateTime CreatedOn { get; set; }

        [BsonElement("modifiedBy")]
        public int ModifiedBy { get; set; }

        [BsonElement("modifiedOn")]
        public DateTime ModifiedOn { get; set; }
    }
}
