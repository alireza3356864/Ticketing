
using MazaNetCOreFw.TicketingDomain.Dto.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Dto.Requests
{
    public class InsertTicketReq
    {
        public InsertTicketReq(Ticket ticket)
        {
            Ticket = ticket;
        }

        public Ticket Ticket { get; }
    }
}
