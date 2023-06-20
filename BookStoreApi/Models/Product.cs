using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Name")]
        [JsonPropertyName("Name")]

        [Required]
        public string Name { get; set; } = null!;
        
        [Required]
        public decimal Price { get; set; }
        [Range(0, 999)]
        public double Weight { get; set; }
    }
}