using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Nutrition.And.Exercise.Domain.Entities
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public string ExpiryDate { get; set; }

        public string Category { get; set; }

    }
}
