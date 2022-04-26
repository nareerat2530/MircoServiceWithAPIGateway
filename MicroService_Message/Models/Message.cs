using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroService_Message.Models
{
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] public string Id { get; set; } = null!;

        [BsonElement("title")]
        public string? Title { get; set; }

        [BsonElement("text")]
        public string? Text { get; set; }

        [BsonElement("date")]
        public DateTime ? Date { get; set; }

        [BsonElement("userId")]
        public int UserId { get; set; }

    }
}
