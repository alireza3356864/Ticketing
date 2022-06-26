using MazaNetCOreFw.Common.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingInfrastructure.ViewModels.Requests.Topics
{
    public class InsertTicketConversationRequest
    {
        public Guid TicketId { get; set; }
        public Guid ParentTicketId { get; set; }
        public TicketStatus Status { get; set; }
        public string Body { get; set; }
    }
}

