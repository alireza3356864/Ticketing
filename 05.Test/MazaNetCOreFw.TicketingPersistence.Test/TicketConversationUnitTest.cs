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
    public class TicketConversationUnitTest
    {
        private IMapper _mapper => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new TicketingProfile());
        }).CreateMapper();
        Guid ticketId = Guid.Parse("071E382A-478D-4833-871E-411BDD2B68E4");
        Guid fromSectionId = Guid.Parse("600a3141-ddfb-4279-bd28-5c405dc3e1a0");
        string fromUserId = "32C83E33-16A9-40CF-A8BE-43B93EE87D28";
        string fromUserName = "store18@surenacs.com";
        string fromSectionName = "سورنا 18";
        string fromSectionCode = "18";
        SectionType fromSectionType = SectionType.Store;


        [Fact]
        public async Task InsertTicketConversation()
        {
            using (TicketingDbContext dbContext = new TicketingDbContextFactory().Create())
            {

                ITicketingUnitOfWork unitOfWork = new TicketingUnitOfWork(_mapper, dbContext);
                var response = await unitOfWork.TicketConversationRepository.InsertAsync(new AppTicketConversation()
                {
                    Body = "test 8",
                    Status = TicketStatus.New,
                    UserId = fromUserId,
                    UserName = fromUserName,
                    SectionId = fromSectionId,
                    SectionCode = fromSectionCode,
                    SectionType = fromSectionType,
                    SectionName = fromSectionName,
                    TicketId= ticketId
                });
                await unitOfWork.SaveChangesAsync();
                Assert.True(response.SuccessCall && response.SuccessOperation);
            }
        }
        [Fact]
        public async Task GetTicketConversationsAsync()
        {
            using (TicketingDbContext dbContext = new TicketingDbContextFactory().Create())
            {
                ITicketingUnitOfWork unitOfWork = new TicketingUnitOfWork(_mapper, dbContext);
                var response = await unitOfWork.TicketConversationRepository.GetByTicketIdAsync(
                     ticketId
                    );
                Assert.True(response.SuccessCall && response.SuccessOperation);
            }
        }



    }
}

