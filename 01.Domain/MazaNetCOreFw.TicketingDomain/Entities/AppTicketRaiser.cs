using MazaNetCOreFw.Common.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Entities
{
    public class AppTicketRaiser
    {
        public string FromUserId { get; set; }
        public string FromUserName { get; set; }
        public Guid FromSectionId { get; set; }
        public string FromSectionName { get; set; }
        public string FromSectionCode { get; set; }
        public SectionType FromSectionType { get; set; }
        public SectionType ToSectionType { get; set; }
        public Guid? ToSectionId { get; set; }
        public string ToSectionCode { get; set; }
        public string ToSectionName { get; set; }
        public string ToUserId { get; set; }
        public string ToUserName { get; set; }

        #region Relation
        public Guid TicketId { get; set; }
        public virtual AppTicket Ticket { get; set; }
        #endregion
    }
}
