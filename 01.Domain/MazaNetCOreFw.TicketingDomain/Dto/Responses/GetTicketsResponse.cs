using MazaNetCOreFw.BaseDomain.Common;

using MazaNetCOreFw.TicketingDomain.Dto.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Dto.Responses
{
    public class GetTicketsResponse : UseCaseResponseMessage
    {
        public GetTicketsResponse(List<Ticket> ticket,
                bool status,
                string message = "") : base(status, message: message)
        {
            Ticket = ticket;
        }
        [JsonConstructor]
        public GetTicketsResponse(bool status,
                                string message = "") : this(null, status, message: message)
        {
        }
        public List<Ticket> Ticket { get; set; }
    }
}
