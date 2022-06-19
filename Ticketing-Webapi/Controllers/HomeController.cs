using AutoMapper;
using MazaNetCOreFw.PAProxyPersistence.Database;
using MazaNetCOreFw.TicketingDomain.Dto.Entities;
using MazaNetCOreFw.TicketingDomain.Dto.Requests;
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

namespace Ticketing_Webapi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private IMapper _mapper => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new TicketingProfile());
        }).CreateMapper();

        private readonly ILogger<HomeController> _logger;
        private readonly IRootTicketingService _rootTicketingService;

        public HomeController(ILogger<HomeController> logger, IRootTicketingService rootTicketingService)
        {
            _logger = logger;
            _rootTicketingService = rootTicketingService;
        }

        [HttpPost]
        public string Get()
        {

                //TicketPresenter ticketPresenter = new TicketPresenter();
             
                //var result = _rootTicketingService.InsertTicketHandle(new InsertTicketReq(
                //       new Ticket()
                //       {
                //           Title = insertTicketRequest.Title
                //       }
                //    ), ticketPresenter);

                return "alireza rezaie";

            
        }
    }
}
