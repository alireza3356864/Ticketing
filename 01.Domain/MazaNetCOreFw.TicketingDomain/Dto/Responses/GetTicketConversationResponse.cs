using MazaNetCOreFw.BaseDomain.Common;

using MazaNetCOreFw.TicketingDomain.Dto.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Dto.Responses
{
    public class GetTicketConversationResponse : UseCaseResponseMessage
    {
        public GetTicketConversationResponse(TicketConversation ticketConversation,
                bool status,
                string message = "") : base(status, message: message)
        {
            TicketConversation = ticketConversation;
        }
        [JsonConstructor]
        public GetTicketConversationResponse(bool status,
                                string message = "") : this(null, status, message: message)
        {
        }
        public TicketConversation TicketConversation { get; set; }
    }
}
