using AutoMapper;
using MazaNetCOreFw.BaseDomain.Common;
using MazaNetCOreFw.Common.Classes;
using MazaNetCOreFw.Common.Utils.Dates;
using MazaNetCOreFw.TicketingDomain.Dto.Entities;
using MazaNetCOreFw.TicketingDomain.Dto.Responses;
using MazaNetCOreFw.TicketingDomain.Entities;
using MazaNetCOreFw.TicketingPersistence.Database;
using MazaNetCOreFw.TicketingPersistence.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MazaNetCOreFw.TicketingPersistence.Repository.Implementations
{
    public class TicketRepository : ITicketRepository
    {
        private readonly IMapper _mapper;
        private readonly TicketingDbContext _dbContext;
        public TicketRepository(IMapper mapper, TicketingDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        /// <summary>
        /// insert a new ticket
        /// </summary>
        /// <param name="appTicket"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetTicketResponse> InsertAsync(AppTicket appTicket, CancellationToken cancellationToken = default)
        {
            try
            {

                appTicket.Year = int.Parse(DateTime.Now.ToPersianDate("yyyy"));
                AppTicketConversation conversation = appTicket.TicketConversations.First();
                //we set the ids manually because we need to return ticket object before it got saved
                appTicket.Id = Guid.NewGuid();
                conversation.Id = Guid.NewGuid();

                conversation.TicketId = appTicket.Id;
                appTicket.TicketRaiser.TicketId = appTicket.Id;

                await _dbContext.Tickets.AddAsync(appTicket, cancellationToken);
                return new GetTicketResponse(_mapper.Map<Ticket>(appTicket), true, "عملیات با موفقیت انجام شد");
            }
            catch (Exception ex)
            {
                return new GetTicketResponse(null, false, $"خطایی رخ داد:{ex.ToString()}");
            }
        }
        /// <summary>
        /// Get all tickets based on criteria
        /// </summary>
        /// <param name="fromUserId"></param>
        /// <param name="fromSectionId"></param>
        /// <param name="fromSectionType"></param>
        /// <param name="toUserId"></param>
        /// <param name="toSectionId"></param>
        /// <param name="toSectionType"></param>
        /// <param name="topicId"></param>
        /// <param name="statusList"></param>
        /// <param name="year"></param>
        /// <param name="ticketPriorities"></param>
        /// <param name="checkActive"></param>
        /// <param name="checkDeleted"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetTicketsResponse> GetAllAsync(string fromUserId = null,
                                                          Guid? fromSectionId = null,
                                                          SectionType? fromSectionType = null,
                                                          string toUserId = null,
                                                          Guid? toSectionId = null,
                                                          SectionType? toSectionType = null,
                                                          Guid? topicId = null,
                                                          List<TicketStatus> statusList = null,
                                                          int? year = null,
                                                          List<TicketPriority> ticketPriorities = null,
                                                          bool checkActive = true,
                                                          bool checkDeleted = true,
                                                          CancellationToken cancellationToken = default)
        {
            try
            {
                //query syntax
                var appTickets = await (from ticket in _dbContext.Tickets.Where(x =>
                                                           (fromUserId == null || x.TicketRaiser.FromUserId == null || x.TicketRaiser.FromUserId.Equals(fromUserId))
                                                        && (fromSectionId == null || x.TicketRaiser.FromSectionId == null || x.TicketRaiser.FromSectionId.Equals(fromSectionId))
                                                        && (fromSectionType == null || x.TicketRaiser.FromSectionType.Equals(fromSectionId))
                                                        && (toUserId == null || x.TicketRaiser.ToUserId == null || x.TicketRaiser.ToUserId.Equals(toUserId))
                                                        && (toSectionId == null || x.TicketRaiser.ToSectionId == null || x.TicketRaiser.ToSectionId.Equals(toSectionId))
                                                        && (toSectionType == null || x.TicketRaiser.ToSectionType.Equals(toSectionType))
                                                        && (topicId == null || x.TopicId == null || x.TopicId.Equals(topicId))
                                                        && (statusList == null || statusList.Contains(x.Status))
                                                        && (year == null || x.Year.Equals(year))
                                                        && (ticketPriorities == null || ticketPriorities.Contains(x.Priority))
                                                        && (!checkActive || x.Active)
                                                        && (!checkDeleted || !x.Deleted))
                                        from ticketRaiser in _dbContext.TicketRaisers.Where(x => x.TicketId.Equals(ticket.Id))
                                        from ticketConversation in _dbContext.TicketConversations.Where(x => x.TicketId.Equals(ticket.Id)
                                                                                                            && (!checkActive || x.Active)
                                                                                                            && (!checkDeleted || !x.Deleted))
                                        from  topic in _dbContext.Topics.Where(x=>x.Id.Equals(ticket.TopicId))
                                        select new
                                        {
                                            ticket,
                                            ticketRaiser,
                                            ticketConversation,
                                            topic
                                        }
                                    )
                .ToListAsync(cancellationToken);
                var result = appTickets.OrderByDescending(x=>x.ticket.Created).GroupBy(x => x.ticket.Id)
                                      .Select(x => _mapper.Map<Ticket>(x.FirstOrDefault()?.ticket)).ToList();
                return new GetTicketsResponse(result, true, "عملیات با موفقیت انجام شد");
            }
            catch (Exception ex)
            {

                return new GetTicketsResponse(null, false, $"خطایی رخ داد:{ex.ToString()}");
            }
        }
        /// <summary>
        /// Update ticket status
        /// </summary>
        /// <param name="Ticketid"></param>
        /// <param name="status"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BaseResponse> UpdateStatusAsync(Guid Ticketid, TicketStatus status, CancellationToken cancellationToken = default)
        {
            try
            {
                var appTicketUpdate = await _dbContext.Tickets.FindAsync(Ticketid);
                if (appTicketUpdate is null)
                {
                    return new BaseResponse(null, false, "تیکتی با مشخصات درخواستی شما یافت نشد");
                }
                appTicketUpdate.Status = status;

                return new BaseResponse(null, true, "عملیات با موفقیت انجام شد");

            }
            catch (Exception ex)
            {
                return new BaseResponse(null, false, $"خطایی رخ داد:{ex.ToString()}");
            }
        }


    }
}
