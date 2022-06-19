
using MazaNetCore.Fw.Api.Common.Utils.Serializers;
using MazaNetCOreFw.BaseDomain.Common;
using MazaNetCOreFw.SharedService.Contract;
using MazaNetCOreFw.TicketingDomain.Dto.Responses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MazaNetCOreFw.TicketingService.Presenters.Topics
{
    public class TicketPresenter : IOutputPort<GetTicketResponse>
    {
        public JsonContentResult ContentResult { get; }
        public TicketPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        public void Handle(GetTicketResponse response)
        {
            ContentResult.StatusCode = (int)(response.SuccessCall ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
