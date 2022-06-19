
using MazaNetCOreFw.TicketingDomain.Dto.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Dto.Requests
{
    public class InsertTicketConversationReq
    {
        public InsertTicketConversationReq(TicketConversation ticketConversation)
        {
            TicketConversation = ticketConversation;
        }

        public TicketConversation TicketConversation { get; }
    }
}
