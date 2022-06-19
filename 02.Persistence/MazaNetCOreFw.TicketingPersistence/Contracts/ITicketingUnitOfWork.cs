using MazaNetCOreFw.TicketingPersistence.Repository.Interfaces;
using System.Threading.Tasks;

namespace MazaNetCOreFw.TicketingPersistence.Contracts
{
    public interface ITicketingUnitOfWork
    {  
        ICodeSequenceRepository CodeSequenceRepository { get; }
        ITicketConversationRepository TicketConversationRepository { get; }
        ITicketRepository TicketRepository { get; }
        ITopicRepository TopicRepository { get; }
        Task<bool> SaveChangesAsync();
        void Clear();
    }
}