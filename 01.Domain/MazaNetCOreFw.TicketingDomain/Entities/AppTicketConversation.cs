using MazaNetCOreFw.BaseDomain;
using MazaNetCOreFw.Common.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Entities
{
    public class AppTicketConversation:BaseEntity
    {
        

        public string Body { get; set; }
        public TicketStatus? Status { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public Guid SectionId { get; set; }
        public string SectionCode { get; set; }
        public SectionType? SectionType { get; set; }
        public string SectionName { get; set; }

        #region Relation
        public Guid TicketId { get; set; }
        public virtual AppTicket Ticket { get; set; }
        public Guid? ParentId { get; set; }       
        public virtual AppTicketConversation ParentTicket { get; set; }
      
        #endregion
    }
}
