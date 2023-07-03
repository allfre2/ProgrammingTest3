namespace Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task Complete();
    }
}
