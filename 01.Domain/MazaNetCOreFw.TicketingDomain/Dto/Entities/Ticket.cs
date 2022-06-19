using MazaNetCOreFw.BaseDomain;
using MazaNetCOreFw.BaseDomain.Common;
using MazaNetCOreFw.Common.Classes;
using MazaNetCOreFw.TicketingDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Dto.Entities
{
    public class Ticket : BaseEntity, IAggregateRoot
    {
        public string Title { get; set; }
        public TicketStatus Status { get; set; }
        public string Code { get; set; }
        public int Year { get; set; }
        public TicketPriority Priority { get; set; }

        #region Relation
        public Guid TopicId { get; set; }
        public  Topic Topic { get; set; }
        public  TicketRaiser TicketRaiser { get; set; }
        public  List<TicketConversation> TicketConversations { get; set; }
        #endregion

    }
}
