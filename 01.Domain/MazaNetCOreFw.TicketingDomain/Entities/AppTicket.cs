using MazaNetCOreFw.BaseDomain;
using MazaNetCOreFw.Common.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Entities
{
    public class AppTicket:BaseEntity
    {
        public string Title { get; set; }
        public TicketStatus Status { get; set; }
        public string Code { get; set; }
        public int Year { get; set; }
        public TicketPriority Priority { get; set; }

        #region Relation
        public Guid TopicId { get; set; }
        public virtual AppTopic Topic { get; set; }
        public virtual AppTicketRaiser TicketRaiser { get; set; }
        public virtual ICollection<AppTicketConversation> TicketConversations { get; set; }
        #endregion

    }
}
