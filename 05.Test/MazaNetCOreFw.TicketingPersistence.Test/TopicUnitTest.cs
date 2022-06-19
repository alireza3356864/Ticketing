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
    public class TopicUnitTest
    {
        Guid topicId = Guid.Parse("E6D1D44E-FE68-4952-A743-FB3C4E8EF9E6");
        Guid ticketId = Guid.Parse("37F1691E-339A-4EF8-9C9C-023B57EAB986");
        Guid fromSectionId = Guid.Parse("600a3141-ddfb-4279-bd28-5c405dc3e1a0");
        string fromUserId = "32C83E33-16A9-40CF-A8BE-43B93EE87D28";
        string fromUserName = "store18@surenacs.com";
        string fromSectionName = "سورنا 18";
        string fromSectionCode = "18";
        SectionType fromSectionType = SectionType.Store;

        private IMapper _mapper => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new TicketingProfile());
        }).CreateMapper();


        [Fact]
        public async Task InsertAsync()
        {
            using (TicketingDbContext dbContext = new TicketingDbContextFactory().Create())
            {
                ITicketingUnitOfWork unitOfWork = new TicketingUnitOfWork(_mapper, dbContext);
                var response = await unitOfWork.TopicRepository.InsertAsync(new AppTopic()
                {
                    Title= "پشتیبانی فنی محصولات",
                    SectionType = SectionType.HeadQuarter,
                    SectionId=Guid.NewGuid(),
                    SectionName = "پشتیبانی A1",
                    UserId = Guid.NewGuid().ToString(),
                    UserName= "جاسم",
                });
                await unitOfWork.SaveChangesAsync();
                Assert.True(response.SuccessCall && response.SuccessOperation);
            }
        }


        [Fact]
        public async Task DeleteAsync()
        {
            using (TicketingDbContext dbContext = new TicketingDbContextFactory().Create())
            {
                ITicketingUnitOfWork unitOfWork = new TicketingUnitOfWork(_mapper, dbContext);
                var response = await unitOfWork.TopicRepository.DeleteAsync(topicId);
                await unitOfWork.SaveChangesAsync();
                Assert.True(response.SuccessCall && response.SuccessOperation);
            }
        }

        [Fact]
        public async Task UpdateAsync() 
        {
            using (TicketingDbContext dbContext = new TicketingDbContextFactory().Create())
            {
                ITicketingUnitOfWork unitOfWork = new TicketingUnitOfWork(_mapper,dbContext);
                var response = await unitOfWork.TopicRepository.UpdateAsync(new AppTopic()
                {
                    Id = topicId,
                    Title = "مشکل در ارسال ",
                    SectionType = fromSectionType,
                    SectionId = null,
                    SectionName = null,
                    UserId = null,
                    UserName = null,

                });
                await unitOfWork.SaveChangesAsync();
                Assert.True(response.SuccessCall && response.SuccessOperation);
            }
        }

        [Fact]
        public async Task GetAllAsync()
        {
            using (TicketingDbContext dbContext = new TicketingDbContextFactory().Create())
            {
                ITicketingUnitOfWork unitOfWork = new TicketingUnitOfWork(_mapper, dbContext);
                var response = await unitOfWork.TopicRepository.GetAllAsync(

                    );
                Assert.True(response.SuccessCall && response.SuccessOperation);
            }
        }

    }
}

