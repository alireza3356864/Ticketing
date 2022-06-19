
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
    public class TicketConversationPresenter : IOutputPort<GetTicketConversationResponse>
    {
        public JsonContentResult ContentResult { get; }
        public TicketConversationPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        public void Handle(GetTicketConversationResponse response)
        {
            ContentResult.StatusCode = (int)(response.SuccessCall ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
