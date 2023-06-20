using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Models;

public class Mapel
{  
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]

    public string? id { get; set; }
    [BsonElement("Name")]
    [JsonPropertyName("Name")]

    public string nama { get; set; } = null!;

    public string kelas { get; set; } = null!;
    
}
