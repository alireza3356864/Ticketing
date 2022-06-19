using MazaNetCOreFw.BaseDomain.Common;

using MazaNetCOreFw.TicketingDomain.Dto.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Dto.Responses
{
    public class TopicsResponse : UseCaseResponseMessage
    {
        public TopicsResponse(List<Topic> topic,
                bool status,
                string message = "") : base(status, message: message)
        {
            Topic = topic;
        }
        [JsonConstructor]
        public TopicsResponse(bool status,
                                string message = "") : this(null, status, message: message)
        {
        }
        public List<Topic> Topic { get; set; }
    }
}
