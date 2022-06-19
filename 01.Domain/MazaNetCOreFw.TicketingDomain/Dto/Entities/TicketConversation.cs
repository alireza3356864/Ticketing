using MazaNetCOreFw.BaseDomain;
using MazaNetCOreFw.BaseDomain.Common;
using MazaNetCOreFw.Common.Classes;
using MazaNetCOreFw.TicketingDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Dto.Entities
{
    public class TicketConversation : BaseEntity, IAggregateRoot
    {
        public string Body { get; set; }
        public TicketStatus Status { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public Guid SectionId { get; set; }
        public string SectionCode { get; set; }
        public SectionType SectionType { get; set; }
        public string SectionName { get; set; }

        #region Relation
        public Guid TicketId { get; set; }
        public Guid? ParentId { get; set; }
        
        #endregion

    }
}
