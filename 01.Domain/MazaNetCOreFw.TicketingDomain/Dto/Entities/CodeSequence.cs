using MazaNetCOreFw.BaseDomain.Common;
using MazaNetCOreFw.Common.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Dto.Entities
{
    public class CodeSequence: IAggregateRoot
    {
        public Guid Id { get; set; }
        public string Prefix { get; set; }
        public int Sequence { get; set; }
        public SectionType? SectionType { get; set; }
        public Guid? SectionId { get; set; }
        public string UserId { get; set; }
    }
}
