using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBSample1.Models
{
    [Serializable]
    public class Blog
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string BlogId { get; set; }

        [BsonElement("title"), BsonRepresentation(BsonType.String)]
        public string Title { get; set; } = string.Empty;
        
        [BsonElement("url"), BsonRepresentation(BsonType.String)]
        public string Url { get; set; } = string.Empty;
        
        [BsonElement("rating"), BsonRepresentation(BsonType.Int32)]
        public int Rating { get; set; } = default;

        //public List<Post>? Posts { get; set; } = default;
    }

}
