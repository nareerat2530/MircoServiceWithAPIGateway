
using MicroService_Message.Interfaces;
using MicroService_Message.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MicroService_Message.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IMongoCollection<Message> _collection;

        public MessageRepository(IOptions<MessageDatabaseSettings> messageDatabaseSettings)
        {
            var mongoClient = new MongoClient(messageDatabaseSettings.Value.ConnectionString);
            
            var mongoDatabase = mongoClient.GetDatabase(messageDatabaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<Message>(messageDatabaseSettings.Value.MessageCollectionName);
        }
        public async Task<IEnumerable<Message>> GetAllMessagesAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Message> GetMessageByIdAsync(string id)
        {
            return await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddNewMessage(Message message)
        {
            await _collection.InsertOneAsync(message);
        }

        public async Task UpdatedMessage(Message message)
        {
             await _collection.ReplaceOneAsync(m => m.Id == message.Id, message);
        }

        public async Task DeleteMessage(string id)
        {
          await  _collection.DeleteOneAsync(m => m.Id == id);
        }
    }
}
