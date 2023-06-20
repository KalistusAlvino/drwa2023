using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Models;

public class Mapel
{  
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]

    public string? nip { get; set; }
    [BsonElement("Name")]
    [JsonPropertyName("Name")]

    public string tgl { get; set; } = null!;

    public string kehadiran { get; set; } = null!;

    public string kelas { get; set; } = null!;
    
}
