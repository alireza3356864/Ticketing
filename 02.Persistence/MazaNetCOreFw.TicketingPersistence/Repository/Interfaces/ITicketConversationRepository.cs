using MazaNetCOreFw.Common.Classes;
using MazaNetCOreFw.TicketingDomain.Dto.Responses;
using MazaNetCOreFw.TicketingDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MazaNetCOreFw.TicketingPersistence.Repository.Interfaces
{
    public interface ITicketConversationRepository
    {
        Task<GetTicketConversationResponse> InsertAsync(AppTicketConversation ticketConversation, CancellationToken cancellationToken = default);
        Task<GetTicketResponse> GetByTicketIdAsync(Guid ticketId, CancellationToken cancellationToken = default);
    }
}






