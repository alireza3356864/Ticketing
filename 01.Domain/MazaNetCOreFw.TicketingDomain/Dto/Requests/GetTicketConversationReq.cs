using MazaNetCOreFw.Common.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Dto.Requests
{
    public class GetTicketConversationReq
    {
        public GetTicketConversationReq(Guid ticketId)
        {
            TicketId = ticketId;
        }
        public Guid TicketId { get; }
    }
}