using AutoMapper;
using MazaNetCOreFw.Common.Classes;
using MazaNetCOreFw.TicketingDomain.Dto.Entities;
using MazaNetCOreFw.TicketingDomain.Dto.Responses;
using MazaNetCOreFw.TicketingDomain.Entities;
using MazaNetCOreFw.TicketingPersistence.Database;
using MazaNetCOreFw.TicketingPersistence.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MazaNetCOreFw.TicketingPersistence.Repository.Implementations
{
    public class TicketConversationRepository: ITicketConversationRepository
    {
        private readonly IMapper _mapper;
        private readonly TicketingDbContext _dbContext;
        public TicketConversationRepository(IMapper mapper, TicketingDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        /// <summary>
        /// Insert a new ticket conversation for a ticket
        /// </summary>
        /// <param name="appTicketConversation"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetTicketConversationResponse> InsertAsync(AppTicketConversation appTicketConversation, CancellationToken cancellationToken = default)
        {
            try
            {
                //we set Id manually because we need to return ticket object with it's id before it got saved
                appTicketConversation.Id= Guid.NewGuid();
                await _dbContext.TicketConversations.AddAsync(appTicketConversation, cancellationToken);
                return new GetTicketConversationResponse(_mapper.Map<TicketConversation>(appTicketConversation), true, "عملیات با موفقیت انجام شد");
            }
            catch (Exception ex)
            {
                return new GetTicketConversationResponse(null, false, $"خطایی رخ داد:{ex.ToString()}");
            }
        }
        /// <summary>
        /// Get ticketConversations by ticketId
        /// </summary>
        /// <param name="ticketId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetTicketResponse> GetByTicketIdAsync(Guid ticketId, CancellationToken cancellationToken = default)
        {
            try
            {
                //query syntax
                var appTickets = await (from ticket in _dbContext.Tickets.Where(x => (x.Id == null || x.Id.Equals(ticketId))                           
                                                        && (x.Active)
                                                        && (!x.Deleted))
                                        from ticketRaiser in _dbContext.TicketRaisers.Where(x => x.TicketId.Equals(ticket.Id))
                                        from ticketConversation in _dbContext.TicketConversations.Where(x => x.TicketId.Equals(ticket.Id)
                                                                                                            && (x.Active)
                                                                                                            && (!x.Deleted))
                                        from topic in _dbContext.Topics.Where(x => x.Id.Equals(ticket.TopicId))
                                        select new
                                        {
                                            topic,
                                            ticket,
                                            ticketRaiser,
                                            ticketConversation
                                        }
                                    )
                .ToListAsync(cancellationToken);

                //get distinct answer
                var result = appTickets.GroupBy(x => x.ticket.Id)
                      .Select(x => _mapper.Map<Ticket>(x.FirstOrDefault()?.ticket)).FirstOrDefault();

                return new GetTicketResponse(result, true, "عملیات با موفقیت انجام شد");
            }
            catch (Exception ex)
            {

                return new GetTicketResponse(null, false, $"خطایی رخ داد:{ex.ToString()}");
            }
        }




    }
}
