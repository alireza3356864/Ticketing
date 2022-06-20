using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketingController : ControllerBase
    {
        [HttpPost]
        public string Post()
        {
            return "alireza";
        }
    }
}
