using MazaNetCOreFw.BaseDomain;
using MazaNetCOreFw.Common.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Entities
{
    public class AppTopic:BaseEntity
    {
        public string Title { get; set; }
        public SectionType? SectionType { get; set; }
        public Guid? SectionId { get; set; }
        public string SectionName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }


        #region Relation
        public virtual ICollection<AppTicket> Tickets { get; set; }
        #endregion
    }
}
