using MazaNetCOreFw.Common.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Dto.Requests
{
    public class GetTopicsReq
    {
        public GetTopicsReq(SectionType? sectionType,
                            Guid? sectionId,
                            string userId,
                            bool checkActive,
                            bool checkDeleted)
        {
            SectionType = sectionType;
            SectionId = sectionId;
            UserId = userId;
            CheckActive = checkActive;
            CheckDeleted = checkDeleted;
        }
        public SectionType? SectionType { get; }
        public Guid? SectionId { get; }
        public string UserId { get; }
        public bool CheckActive { get; }
        public bool CheckDeleted { get; }
    }
}