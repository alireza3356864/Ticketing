using MazaNetCOreFw.Common.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingInfrastructure.ViewModels.Requests.Topics
{
    public class InsertTicketRequest
    {
        public string Title { get; set; }
        public Guid TopicId { get; set; }
        public TicketStatus Status { get; set; }
        public TicketPriority Priority { get; set; }
        public string Body { get; set; }
        public SectionType? SectionType { get; set; }
        public Guid? SectionId { get; set; }
        public string UserId { get; set; }
    }
}

