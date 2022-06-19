using MazaNetCOreFw.BaseDomain.Common;

using MazaNetCOreFw.TicketingDomain.Dto.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Dto.Responses
{
    public class GetTicketResponse : UseCaseResponseMessage
    {
        public GetTicketResponse(Ticket ticket,
                bool status,
                string message = "") : base(status, message: message)
        {
            Ticket = ticket;
        }
        [JsonConstructor]
        public GetTicketResponse(bool status,
                                string message = "") : this(null, status, message: message)
        {
        }
        public Ticket Ticket { get; set; }
    }
}
