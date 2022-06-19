using AutoMapper;
using MazaNetCOreFw.TicketingDomain.Dto.Entities;
using MazaNetCOreFw.TicketingDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingPersistence.Mapping
{
    public class TicketingProfile : Profile
    {
        public TicketingProfile()
        {

            CreateMap<Ticket, AppTicket>()
              .ReverseMap();

            CreateMap<Topic, AppTopic>()
           .ReverseMap();

            CreateMap<CodeSequence, AppCodeSequence>()
               .ReverseMap();

            CreateMap<TicketConversation, AppTicketConversation>()
               .ReverseMap();

            CreateMap<TicketRaiser, AppTicketRaiser>()
             .ReverseMap();

        }
    }
}
