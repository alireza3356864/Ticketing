using MazaNetCOreFw.Common.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingInfrastructure.ViewModels.Requests.Topics
{
    public class UpdateTopicRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public SectionType? SectionType { get; set; }
        public Guid? SectionId { get; set; }
        public string SectionName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
