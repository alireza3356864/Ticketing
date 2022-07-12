using MazaNetCOreFw.BaseDomain.Common;
using MazaNetCOreFw.SharedService.Contract;
using MazaNetCOreFw.TicketingDomain.Dto.Requests;
using MazaNetCOreFw.TicketingDomain.Dto.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MazaNetCOreFw.TicketingService.Contracts
{
    public interface IRootTicketingService
    {
        Task<bool> InsertTopicHandle(InsertTopicReq message,IOutputPort<BaseResponse> outputPort);
        Task<bool> GetAllTopicsHandle(GetTopicsReq message,IOutputPort<TopicsResponse> outputPort);
        Task<bool> DeleteTopicHandle(DeleteTopicReq message, IOutputPort<BaseResponse> outputPort);
        Task<bool> UpdateTopicHandle(UpdateTopicReq message, IOutputPort<BaseResponse> outputPort);
        Task<bool> InsertCodeSequenceHandle(InsertCodeSequenceReq message, IOutputPort<BaseResponse> outputPort);
        Task<bool> InsertTicketHandle(InsertTicketReq message, IOutputPort<GetTicketResponse> outputPort);
        Task<bool> GetAllTicketsHandle(GetTicketsReq message, IOutputPort<GetTicketsResponse> outputPort);
        Task<bool> InsertTicketConversationHandle(InsertTicketConversationReq message, IOutputPort<GetTicketConversationResponse> outputPort);
        Task<bool> GetTicketConversationsHandle(GetTicketConversationReq message, IOutputPort<GetTicketConversationsResponse> outputPort);

    }
}
