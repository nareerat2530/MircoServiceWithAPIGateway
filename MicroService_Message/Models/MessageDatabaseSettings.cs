using MongoDB.Bson.Serialization.Serializers;

namespace MicroService_Message.Models
{
    public class MessageDatabaseSettings 
    {
       
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;

        public string MessageCollectionName { get; set; } = null!;
    }
}
