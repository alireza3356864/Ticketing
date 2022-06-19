
using MazaNetCOreFw.TicketingDomain.Dto.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Dto.Requests
{
    public class InsertTopicReq
    {
        public InsertTopicReq(Topic topic)
        {
            Topic = topic;
        }

        public Topic Topic { get; }
    }
}
