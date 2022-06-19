
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Dto.Requests
{
    public class DeleteTopicReq
    {
        public DeleteTopicReq(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}