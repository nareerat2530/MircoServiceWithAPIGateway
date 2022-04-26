namespace MicroService_User.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        Task<bool> Complete();

    }
}
