using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmericaVirtualApi.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("IsAdmin")]
        public bool isAdmin { get; set; }

        [BsonElement("FullName")]
        public string FullName { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        /// <summary>
        /// imagen en base64.
        /// </summary>
        [BsonElement("Image")]
        public string Image { get; set; }

        [BsonElement("Birthday")]
        public DateTime Birthday { get; set; }
    }
}
