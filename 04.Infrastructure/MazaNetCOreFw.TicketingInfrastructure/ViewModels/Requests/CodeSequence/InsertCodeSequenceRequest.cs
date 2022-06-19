using MazaNetCOreFw.Common.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingInfrastructure.ViewModels.Requests.Topics
{
    public class InsertCodeSequenceRequest
    {
        public string Prefix { get; set; }
        public int Sequence { get; set; }
        public SectionType? SectionType { get; set; }
        public Guid? SectionId { get; set; }
        public string UserId { get; set; }
    }
}
