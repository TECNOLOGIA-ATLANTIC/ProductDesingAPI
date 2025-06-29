using AtlanticProductDesing.Domain.Common;
using AtlanticProductDesing.Domain.Entities;

namespace AtlanticProductDesing.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        //IStreamerRepository StreamerRepository { get; }
        //IVideoRepository VideoRepository { get; }
        //IWalletTokenRepository WalletTokenRepository { get; }
        //IProjectRepository ProjectRepository { get; }
        //IWalletRepository WalletRepository { get; }

        //IEventRepository EventRepository { get; }


        IAsyncRepository<Person> PersonRepository { get; }




        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> Complete();

    }
}
