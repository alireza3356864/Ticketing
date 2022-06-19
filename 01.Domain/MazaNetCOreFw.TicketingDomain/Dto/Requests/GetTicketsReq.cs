using MazaNetCOreFw.Common.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Dto.Requests
{
    public class GetTicketsReq
    {
        public GetTicketsReq(string fromUserId = null,
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
                             bool checkDeleted = true)
        {
            FromUserId = fromUserId;
            FromSectionId = fromSectionId;
            FromSectionType = fromSectionType;
            ToUserId = toUserId;
            ToSectionId = toSectionId;
            ToSectionType = toSectionType;
            TopicId = topicId;
            StatusList = statusList;
            Year = year;
            TicketPriorities = ticketPriorities;
            CheckActive = checkActive;
            CheckDeleted = checkDeleted;
        }
        public string FromUserId { get; }
        public Guid? FromSectionId { get; }
        public SectionType? FromSectionType { get; }
        public string ToUserId { get; }
        public Guid? ToSectionId { get; }
        public SectionType? ToSectionType { get; }
        public Guid? TopicId { get; }
        public List<TicketStatus> StatusList { get; }
        public int? Year { get; }
        public List<TicketPriority> TicketPriorities { get; }
        public bool CheckActive { get; }
        public bool CheckDeleted { get; }
    }
}