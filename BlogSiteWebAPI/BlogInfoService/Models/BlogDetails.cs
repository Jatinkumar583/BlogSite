using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BlogInfoService.Models
{
    [BsonIgnoreExtraElements]
    public class BlogDetails
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("blogId")]
        public int BlogId { get; set; }

        [BsonElement("blogName")]
        public string BlogName { get; set; } = string.Empty;

        [BsonElement("category")]
        public string Category { get; set; } = string.Empty;

        [BsonElement("article")]
        public string Article { get; set; } = string.Empty;

        [BsonElement("authorName")]
        public string AuthorName { get; set; }=string.Empty;

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
