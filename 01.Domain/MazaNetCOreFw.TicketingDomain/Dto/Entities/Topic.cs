using MazaNetCOreFw.BaseDomain;
using MazaNetCOreFw.BaseDomain.Common;
using MazaNetCOreFw.Common.Classes;
using MazaNetCOreFw.TicketingDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Dto.Entities
{
    public class Topic:BaseEntity, IAggregateRoot
    {
        public string Title { get; set; }
        public SectionType? SectionType { get; set; }
        public Guid? SectionId { get; set; }
        public string SectionName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }




    }
}
