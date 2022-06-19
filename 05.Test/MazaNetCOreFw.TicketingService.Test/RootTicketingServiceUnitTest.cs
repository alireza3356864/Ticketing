using AutoMapper;
using MazaNetCOreFw.Common.Classes;
using MazaNetCOreFw.PAProxyPersistence.Database;
using MazaNetCOreFw.TicketingDomain.Dto.Requests;
using MazaNetCOreFw.TicketingDomain.Entities;
using MazaNetCOreFw.TicketingPersistence.Contracts;
using MazaNetCOreFw.TicketingPersistence.Database;
using MazaNetCOreFw.TicketingPersistence.Implementations;
using MazaNetCOreFw.TicketingPersistence.Mapping;
using MazaNetCOreFw.TicketingService.Implementations;
using MazaNetCOreFw.TicketingService.Presenters.Topics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MazaNetCOreFw.TicketingDomain.Dto.Entities;
using MazaNetCOreFw.SharedService.Implementation;
using System.Globalization;
using Newtonsoft.Json;
using MazaNetCOreFw.TicketingDomain.Dto.Responses;

namespace MazaNetCOreFw.TicketingService.Test
{
    public class RootTicketingServiceUnitTest
    {
        Guid topicId = Guid.Parse("E6D1D44E-FE68-4952-A743-FB3C4E8EF9E6");
        Guid ticketId = Guid.Parse("27A5895A-F37F-48B1-8880-8277F0942458");
        Guid fromSectionId = Guid.Parse("600a3141-ddfb-4279-bd28-5c405dc3e1a0");
        string fromUserId = "32C83E33-16A9-40CF-A8BE-43B93EE87D28";
        string fromUserName = "store18@surenacs.com";
        string fromSectionName = "سورنا 18";
        string fromSectionCode = "18";
        SectionType toSectionType = SectionType.HeadQuarter;
        SectionType fromSectionType = SectionType.Store;

        private IMapper _mapper => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new TicketingProfile());
        }).CreateMapper();



        [Fact]
        public async Task InsertTopicsTest()
        {
            using (TicketingDbContext dbContext = new TicketingDbContextFactory().Create())
            {
                var unitOfWork = new TicketingUnitOfWork(_mapper, dbContext);
                RootTicketingService rootDummyService = new RootTicketingService(unitOfWork, _mapper);
                CommonPresenter commonPresenter = new CommonPresenter();

                var result = await rootDummyService.InsertTopicHandle(new InsertTopicReq(new Topic()
                {
                    Title = "پشتیبانی فنی",
                    SectionType = fromSectionType,
                    SectionId = null,
                    SectionName = null,
                    UserId = null,
                    UserName = null,

                }), commonPresenter);
                Assert.True(result);
            }
        }



        [Fact]
        public async Task UpdateTopicTest()
        {
            using (TicketingDbContext dbContext = new TicketingDbContextFactory().Create())
            {

                var unitOfWork = new TicketingUnitOfWork(_mapper, dbContext);
                RootTicketingService rootDummyService = new RootTicketingService(unitOfWork, _mapper);
                CommonPresenter commonPresenter = new CommonPresenter();


                var result = await rootDummyService.UpdateTopicHandle(new UpdateTopicReq(new Topic()
                {
                    Id = topicId,
                    Title = "پشتیبانی فنی1",
                    SectionType = toSectionType,
                    SectionId = fromSectionId,
                    SectionName = fromSectionName,
                    UserId = fromUserId,
                    UserName = fromUserName,

                }), commonPresenter);
                Assert.True(result);
            }
        }



        [Fact]
        public async Task DeleteTopicsTest()
        {
            using (TicketingDbContext dbContext = new TicketingDbContextFactory().Create())
            {
                var unitOfWork = new TicketingUnitOfWork(_mapper, dbContext);
                RootTicketingService rootDummyService = new RootTicketingService(unitOfWork, _mapper);
                CommonPresenter commonPresenter = new CommonPresenter();

                var result = await rootDummyService.DeleteTopicHandle(new DeleteTopicReq(topicId),commonPresenter);
                Assert.True(result);
            }
        }


        [Fact]
        public async Task GetAllTopicTest()
        {
            using (TicketingDbContext dbContext = new TicketingDbContextFactory().Create())
            {
                var unitOfWork = new TicketingUnitOfWork(_mapper, dbContext);
                RootTicketingService rootDummyService = new RootTicketingService(unitOfWork, _mapper);
                TopicsPresenter topicPresenter = new TopicsPresenter();

                var result = await rootDummyService.GetAllTopicsHandle(new GetTopicsReq(
                     SectionType.Store,
                     fromSectionId,
                     fromUserId,
                     false,
                     false
                    ), topicPresenter);
                Assert.True(result);
            }
        }



        [Fact]
        public async Task InsertCodeSequenceTest()
        {
            using (TicketingDbContext dbContext = new TicketingDbContextFactory().Create())
            {
                var unitOfWork = new TicketingUnitOfWork(_mapper, dbContext);
                RootTicketingService rootDummyService = new RootTicketingService(unitOfWork, _mapper);
                CommonPresenter commonPresenter = new CommonPresenter();
                var result = await rootDummyService.InsertCodeSequenceHandle(new InsertCodeSequenceReq(new CodeSequence()
                {
                    Prefix = "StoreT10-",
                    Sequence = 1,
                    SectionType = fromSectionType,
                    SectionId = null,
                    UserId = null

                }), commonPresenter);
                Assert.True(result);
            }
        }



        [Fact]
        public async Task InsertTicketTest()
        {
            using (TicketingDbContext dbContext = new TicketingDbContextFactory().Create())
            {
                var unitOfWork = new TicketingUnitOfWork(_mapper, dbContext);
                RootTicketingService rootDummyService = new RootTicketingService(unitOfWork, _mapper);
                TicketPresenter ticketPresenter = new TicketPresenter();

                
                var result = await rootDummyService.InsertTicketHandle(new InsertTicketReq(new Ticket()
                {
                    Title = "test ticket",
                    Status = TicketStatus.New,
                    Priority = TicketPriority.Low,
                    TopicId = topicId,

                    TicketRaiser = new TicketRaiser()
                    {
                        FromUserId = fromUserId,
                        FromUserName = fromUserName,
                        FromSectionId = fromSectionId,
                        FromSectionName = fromSectionName,
                        FromSectionCode = fromSectionCode,
                        FromSectionType = fromSectionType,
                        ToSectionType = SectionType.HeadQuarter,
                    },
                    TicketConversations = new List<TicketConversation>() {
                    new TicketConversation() {
                         Body = "مشکل در ثبت سفارش محصولات فروشگاه",
                         Status =TicketStatus.New,
                         UserId = fromUserId,
                         UserName = fromUserName,
                         SectionId = fromSectionId,
                         SectionCode = fromSectionCode,
                         SectionType = fromSectionType,
                         SectionName = fromSectionName
                        }
                    }
                }), ticketPresenter);
                var ticketResponse = JsonConvert.DeserializeObject<GetTicketResponse>(ticketPresenter.ContentResult.Content);
                Assert.True(ticketResponse.SuccessCall && ticketResponse.SuccessOperation);
            }
        }



        [Fact]
        public async Task GetAllTicketsTest()
        {
            using (TicketingDbContext dbContext = new TicketingDbContextFactory().Create())
            {
                var unitOfWork = new TicketingUnitOfWork(_mapper, dbContext);
                RootTicketingService rootDummyService = new RootTicketingService(unitOfWork, _mapper);
                TicketsPresenter ticketsPresenter = new TicketsPresenter();

                var result = await rootDummyService.GetAllTicketsHandle(new GetTicketsReq(fromSectionId:Guid.Parse("7B707DEB-9F58-4A0F-8518-A089D0386DBC")), ticketsPresenter);
                var ticketsResponse = JsonConvert.DeserializeObject<GetTicketsResponse>(ticketsPresenter.ContentResult.Content);
                Assert.True(ticketsResponse.SuccessCall && ticketsResponse.SuccessOperation);
            }
        }



        [Fact]
        public async Task InsertTicketConversationTest()
        {
            using (TicketingDbContext dbContext = new TicketingDbContextFactory().Create())
            {
                var unitOfWork = new TicketingUnitOfWork(_mapper, dbContext);
                RootTicketingService rootDummyService = new RootTicketingService(unitOfWork, _mapper);
                TicketConversationPresenter ticketConversationPresenter = new TicketConversationPresenter();

                var result = await rootDummyService.InsertTicketConversationHandle(new InsertTicketConversationReq(new TicketConversation()
                {
                    Body = "مشکل در ثبت محصولات فروشگاه",
                    Status = TicketStatus.Closed,
                    UserId = fromUserId,
                    UserName = fromUserName,
                    SectionId = fromSectionId,
                    SectionCode = fromSectionCode,
                    SectionType = fromSectionType,
                    SectionName = fromSectionName,
                    TicketId = ticketId,
                    ParentId=Guid.Parse("F6375886-AA31-4BC2-B4CD-72EB15D25E85")

                }), ticketConversationPresenter);
                var ticketConversationResponse = JsonConvert.DeserializeObject<GetTicketConversationResponse>(ticketConversationPresenter.ContentResult.Content);
                Assert.True(ticketConversationResponse.SuccessCall && ticketConversationResponse.SuccessOperation);
            }
        }



        [Fact]
        public async Task GetTicketConversationsTest()
        {
            using (TicketingDbContext dbContext = new TicketingDbContextFactory().Create())
            {
                var unitOfWork = new TicketingUnitOfWork(_mapper, dbContext);
                RootTicketingService rootDummyService = new RootTicketingService(unitOfWork, _mapper);
                TicketPresenter ticketPresenter = new TicketPresenter();

                var result = await rootDummyService.GetTicketConversationsHandle(new GetTicketConversationReq(ticketId)
                    , ticketPresenter);
                var ticketConversationsResponse = JsonConvert.DeserializeObject<GetTicketResponse>(ticketPresenter.ContentResult.Content);
                Assert.True(ticketConversationsResponse.SuccessCall && ticketConversationsResponse.SuccessOperation);

            }
        }

    }
}
