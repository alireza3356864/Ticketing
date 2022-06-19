using AutoMapper;
using MazaNetCOreFw.Common.Classes;
using MazaNetCOreFw.PAProxyPersistence.Database;
using MazaNetCOreFw.TicketingDomain.Entities;
using MazaNetCOreFw.TicketingPersistence.Contracts;
using MazaNetCOreFw.TicketingPersistence.Database;
using MazaNetCOreFw.TicketingPersistence.Implementations;
using MazaNetCOreFw.TicketingPersistence.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MazaNetCOreFw.TicketingPersistence.Test
{
    public class TicketUnitTest
    {
        Guid ticketId = Guid.Parse("37F1691E-339A-4EF8-9C9C-023B57EAB986");
        Guid fromSectionId = Guid.Parse("600a3141-ddfb-4279-bd28-5c405dc3e1a0");
        string fromUserId = "32C83E33-16A9-40CF-A8BE-43B93EE87D28";
        string fromUserName = "store18@surenacs.com";
        string fromSectionName = "سورنا 18";
        string fromSectionCode = "18";
        SectionType fromSectionType = SectionType.Store;
        Guid topicId = Guid.Parse("E6D1D44E-FE68-4952-A743-FB3C4E8EF9E6");

        private IMapper _mapper => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new TicketingProfile());
        }).CreateMapper();


        [Fact]
        public async Task InsertTicket()
        {
            using (TicketingDbContext dbContext = new TicketingDbContextFactory().Create())
            {

                ITicketingUnitOfWork unitOfWork = new TicketingUnitOfWork(_mapper, dbContext);

                var response = await unitOfWork.TicketRepository.InsertAsync(new AppTicket()
                {
                    Title = "مشکل در ثبت محصول",
                    Status = TicketStatus.RecipientAnswered,
                    Code = "StorT8-18",
                    Priority = TicketPriority.Low,
                    TopicId = topicId,
                    TicketRaiser = new AppTicketRaiser()
                    {
                        FromUserId = fromUserId,
                        FromUserName = fromUserName,
                        FromSectionId = fromSectionId,
                        FromSectionName = fromSectionName,
                        FromSectionCode = fromSectionCode,
                        FromSectionType = fromSectionType,
                        ToSectionType = SectionType.HeadQuarter,
                    },
                    TicketConversations = new List<AppTicketConversation>() {
                    new AppTicketConversation() {
                         Body = "مشکل دارم",
                         Status =TicketStatus.New,
                         UserId = fromUserId,
                         UserName = fromUserName,
                         SectionId = fromSectionId,
                         SectionCode = fromSectionCode,
                         SectionType = fromSectionType,
                         SectionName = fromSectionName
                       }
                    }
                });
                await unitOfWork.SaveChangesAsync();
                Assert.True(response.SuccessCall && response.SuccessOperation);
            }
        }

        [Fact]
        public async Task GetAllTicketAsync()
        {
            using (TicketingDbContext dbContext = new TicketingDbContextFactory().Create())
            {
                ITicketingUnitOfWork unitOfWork = new TicketingUnitOfWork(_mapper, dbContext);
                var response = await unitOfWork.TicketRepository.GetAllAsync();
                Assert.True(response.SuccessCall && response.SuccessOperation);
            }
        }

    }
}

