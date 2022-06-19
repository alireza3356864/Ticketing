using MazaNetCOreFw.BaseDomain.Common;
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
    public interface ITicketRepository
    {
        Task<GetTicketResponse> InsertAsync(AppTicket ticket, CancellationToken cancellationToken = default);
        Task<GetTicketsResponse> GetAllAsync(string fromUserId = null, Guid? fromSectionId = null, SectionType? fromSectionType = null, string toUserId = null, Guid? toSectionId = null, SectionType? toSectionType = null, Guid? topicId = null, List<TicketStatus> statusList = null, int? year = null, List<TicketPriority> ticketPriorities = null, bool checkActive = true, bool checkDeleted = true, CancellationToken cancellationToken = default);
        Task<BaseResponse> UpdateStatusAsync(Guid ticketId, TicketStatus status, CancellationToken cancellationToken = default);


    }
}
