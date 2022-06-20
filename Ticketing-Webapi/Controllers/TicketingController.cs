using AutoMapper;
using MazaNetCOreFw.Common.Classes;
using MazaNetCOreFw.PAProxyPersistence.Database;
using MazaNetCOreFw.TicketingDomain.Dto.Entities;
using MazaNetCOreFw.TicketingDomain.Dto.Requests;
using MazaNetCOreFw.TicketingDomain.Dto.Responses;
using MazaNetCOreFw.TicketingInfrastructure.ViewModels.Requests.Topics;
using MazaNetCOreFw.TicketingPersistence.Contracts;
using MazaNetCOreFw.TicketingPersistence.Database;
using MazaNetCOreFw.TicketingPersistence.Implementations;
using MazaNetCOreFw.TicketingPersistence.Mapping;
using MazaNetCOreFw.TicketingService.Contracts;
using MazaNetCOreFw.TicketingService.Implementations;
using MazaNetCOreFw.TicketingService.Presenters.Topics;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ticketing_Webapi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class TicketingController : Controller
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

        private readonly ILogger<TicketingController> _logger;
        private readonly IRootTicketingService _rootTicketingService;

        public TicketingController(ILogger<TicketingController> logger, IRootTicketingService rootTicketingService)
        {
            _logger = logger;
            _rootTicketingService = rootTicketingService;
        }
        [HttpGet]
        public string Index() {
            return "Welcome";
        }
        [HttpPost]
        [Route("InsertTicket")]
        public async Task<ActionResult> InsertTicket(InsertTicketRequest insertTicketRequest)
        {
            
                TicketPresenter ticketPresenter = new TicketPresenter();
            
                var result =await _rootTicketingService.InsertTicketHandle(new InsertTicketReq(
                       new Ticket()
                       {
                           Title = insertTicketRequest.Title,
                           Status = insertTicketRequest.Status,
                           Priority = insertTicketRequest.Priority,
                           TopicId = insertTicketRequest.TopicId,

                           TicketRaiser = new TicketRaiser()
                           {
                               FromUserId = fromUserId,
                               FromUserName = fromUserName,
                               FromSectionId = fromSectionId,
                               FromSectionName = fromSectionName,
                               FromSectionCode = fromSectionCode,
                               FromSectionType = fromSectionType,
                               ToSectionType = SectionType.HeadQuarter
                           },

                           TicketConversations = new List<TicketConversation>() {
                          new TicketConversation() {
                         Body = insertTicketRequest.Body,
                         Status = insertTicketRequest.Status,
                         UserId = fromUserId,
                         UserName = fromUserName,
                         SectionId = fromSectionId,
                         SectionCode = fromSectionCode,
                         SectionType = fromSectionType,
                         SectionName = fromSectionName
                        }
                        }
                       }

                    ), ticketPresenter);

                return ticketPresenter.ContentResult;
            

            
        }
    }
}
