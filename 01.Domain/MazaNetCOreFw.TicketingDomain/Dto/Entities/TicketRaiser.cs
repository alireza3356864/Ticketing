using MazaNetCOreFw.BaseDomain.Common;
using MazaNetCOreFw.Common.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Dto.Entities
{
    public class TicketRaiser: IAggregateRoot
    {
        public Guid TicketId { get; set; }
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
    }
}
