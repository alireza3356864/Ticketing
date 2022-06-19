using MazaNetCOreFw.BaseDomain;
using MazaNetCOreFw.Common.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Entities
{
    public class AppCodeSequence
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Prefix { get; set; }
        public int Sequence { get; set; }
        public SectionType? SectionType { get; set; }
        public Guid? SectionId { get; set; }
        public string UserId { get; set; }
    }
}
