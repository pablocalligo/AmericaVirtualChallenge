using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmericaVirtualApi.Models
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Imagen en base64
        /// </summary>
        [BsonElement("Image")]
        public string Image { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }
    }
}
