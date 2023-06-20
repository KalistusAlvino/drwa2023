using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Models;

public class Guru
{  
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]

    public string? nip { get; set; }
    [BsonElement("Name")]
    [JsonPropertyName("Name")]

    public string nama { get; set; } = null!;

    public string kelas { get; set; } = null!;
    
}
