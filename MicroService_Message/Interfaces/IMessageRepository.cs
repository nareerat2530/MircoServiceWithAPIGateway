using MicroService_Message.Models;

namespace MicroService_Message.Interfaces
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetAllMessagesAsync();
        Task<Message> GetMessageByIdAsync(string id);
        Task AddNewMessage(Message message);
        Task UpdatedMessage(Message message);
        Task DeleteMessage(string id);
    }
}
