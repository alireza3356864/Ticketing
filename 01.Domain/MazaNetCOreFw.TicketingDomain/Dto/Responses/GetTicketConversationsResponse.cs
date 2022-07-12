using MazaNetCOreFw.BaseDomain.Common;

using MazaNetCOreFw.TicketingDomain.Dto.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Dto.Responses
{
    public class GetTicketConversationsResponse : UseCaseResponseMessage
    {
        public GetTicketConversationsResponse(List<TicketConversation> ticketConversations,
                bool status,
                string message = "") : base(status, message: message)
        {
            TicketConversations = ticketConversations;
        }
        [JsonConstructor]
        public GetTicketConversationsResponse(bool status,
                                string message = "") : this(null, status, message: message)
        {
        }
        public List<TicketConversation> TicketConversations { get; set; }
    }
}
