using AutoMapper;
using MazaNetCOreFw.BaseDomain.Common;
using MazaNetCOreFw.TicketingDomain.Entities;
using MazaNetCOreFw.TicketingPersistence.Contracts;
using MazaNetCOreFw.TicketingService.Contracts;
using MazaNetCOreFw.SharedService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MazaNetCOreFw.TicketingDomain.Dto.Requests;
using MazaNetCOreFw.TicketingDomain.Dto.Responses;
using MazaNetCOreFw.Common.Classes;

namespace MazaNetCOreFw.TicketingService.Implementations
{
    public class RootTicketingService : IRootTicketingService
    {
        private readonly ITicketingUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RootTicketingService(ITicketingUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /// <summary>
        /// insert a new topic
        /// </summary>
        /// <param name="message"></param>
        /// <param name="outputPort"></param>
        /// <returns></returns>
        public async Task<bool> InsertTopicHandle(InsertTopicReq message, IOutputPort<BaseResponse> outputPort)
        {
            try
            {
                var topicResult = await _unitOfWork.TopicRepository.InsertAsync(_mapper.Map<AppTopic>(message.Topic));
                await _unitOfWork.SaveChangesAsync();
                outputPort.Handle(topicResult);
                return true;
            }
            catch (Exception ex)
            {
                outputPort.Handle(new BaseResponse(null, false, $"خطایی رخ داد:{ex.ToString()}"));
                return false;
            }
            finally
            {
                _unitOfWork.Clear();
            }
        }

        /// <summary>
        /// get all topics
        /// </summary>
        /// <param name="message"></param>
        /// <param name="outputPort"></param>
        /// <returns></returns>
        public async Task<bool> GetAllTopicsHandle(GetTopicsReq message, IOutputPort<TopicsResponse> outputPort)
        {
            try
            {
                var topicsResult = await _unitOfWork.TopicRepository.GetAllAsync(message.SectionType,
                                                                                 message.SectionId,
                                                                                 message.UserId,
                                                                                 message.CheckActive,
                                                                                 message.CheckDeleted);
                outputPort.Handle(topicsResult);
                return true;
            }
            catch (Exception ex)
            {
                outputPort.Handle(new TopicsResponse(null, false, $"خطایی رخ داد:{ex.ToString()}"));
                return false;
            }
        }
        /// <summary>
        ///  Delete a topic
        /// </summary>
        /// <param name="message"></param>
        /// <param name="outputPort"></param>
        /// <returns></returns>
        public async Task<bool> DeleteTopicHandle(DeleteTopicReq message, IOutputPort<BaseResponse> outputPort)
        {
            try
            {
                var topicResult = await _unitOfWork.TopicRepository.DeleteAsync(message.Id);
                await _unitOfWork.SaveChangesAsync();
                outputPort.Handle(topicResult);
                return true;
            }
            catch (Exception ex)
            {
                outputPort.Handle(new BaseResponse(null, false, $"خطایی رخ داد:{ex.ToString()}"));
                return false;
            }
            finally
            {
                _unitOfWork.Clear();
            }
        }
        /// <summary>
        /// Update a Topic
        /// </summary>
        /// <param name="message"></param>
        /// <param name="outputPort"></param>
        /// <returns></returns>
        public async Task<bool> UpdateTopicHandle(UpdateTopicReq message, IOutputPort<BaseResponse> outputPort)
        {
            try
            {
                var topicResult = await _unitOfWork.TopicRepository.UpdateAsync(_mapper.Map<AppTopic>(message.Topic));
                await _unitOfWork.SaveChangesAsync();
                outputPort.Handle(topicResult);
                return true;
            }
            catch (Exception ex)
            {
                outputPort.Handle(new BaseResponse(null, false, $"خطایی رخ داد:{ex.ToString()}"));
                return false;
            }
            finally
            {
                _unitOfWork.Clear();
            }
        }
        /// <summary>
        /// Insert new Code Sequence
        /// </summary>
        /// <param name="message"></param>
        /// <param name="outputPort"></param>
        /// <returns></returns>
        public async Task<bool> InsertCodeSequenceHandle(InsertCodeSequenceReq message, IOutputPort<BaseResponse> outputPort)
        {
            try
            {
                var CodeSequenceResult = await _unitOfWork.CodeSequenceRepository.InsertAsync(_mapper.Map<AppCodeSequence>(message.CodeSequence));
                await _unitOfWork.SaveChangesAsync();
                outputPort.Handle(CodeSequenceResult);
                return true;
            }
            catch (Exception ex)
            {
                outputPort.Handle(new BaseResponse(null, false, $"خطایی رخ داد:{ex.ToString()}"));
                return false;
            }
            finally
            {
                _unitOfWork.Clear();
            }
        }
        /// <summary>
        /// generate code for ticket and insert a new ticket and get ticket
        /// </summary>
        /// <param name="message"></param>
        /// <param name="outputPort"></param>
        /// <returns></returns>
        public async Task<bool> InsertTicketHandle(InsertTicketReq message, IOutputPort<GetTicketResponse> outputPort)
        {
            try
            {
                //Generate a ticket code 
                GenerateCodeResponse generateCodeResponse = await _unitOfWork.CodeSequenceRepository.GenerateCodeAsync(
                    message.Ticket.TicketRaiser.FromSectionType,
                    message.Ticket.TicketRaiser.FromSectionId,
                    message.Ticket.TicketRaiser.FromUserId
                    );
                if (!generateCodeResponse.SuccessCall || !generateCodeResponse.SuccessOperation)
                {
                    outputPort.Handle(new GetTicketResponse(null, false, generateCodeResponse.Message));
                    return false;
                }
                message.Ticket.Code = generateCodeResponse.Code;
                //insert ticket
                GetTicketResponse TicketResult = await _unitOfWork.TicketRepository.InsertAsync(_mapper.Map<AppTicket>(message.Ticket));
                await _unitOfWork.SaveChangesAsync();
                outputPort.Handle(TicketResult);
                return true;
            }
            catch (Exception ex)
            {
                outputPort.Handle(new GetTicketResponse(null, false, $"خطایی رخ داد:{ex.ToString()}"));
                return false;
            }
            finally
            {
                _unitOfWork.Clear();
            }

        }
        /// <summary>
        /// Get all tickets based on criteria
        /// </summary>
        /// <param name="message"></param>
        /// <param name="outputPort"></param>
        /// <returns></returns>
        public async Task<bool> GetAllTicketsHandle(GetTicketsReq message, IOutputPort<GetTicketsResponse> outputPort)
        {
            try
            {
                var ticketsResult = await _unitOfWork.TicketRepository.GetAllAsync(
                    message.FromUserId,
                    message.FromSectionId,
                    message.FromSectionType,
                    message.ToUserId,
                    message.ToSectionId,
                    message.ToSectionType,
                    message.TopicId,
                    message.StatusList,
                    message.Year,
                    message.TicketPriorities,
                    message.CheckActive,
                    message.CheckDeleted
                    );
                outputPort.Handle(ticketsResult);
                return true;
            }
            catch (Exception ex)
            {
                outputPort.Handle(new GetTicketsResponse(null, false, $"خطایی رخ داد:{ex.ToString()}"));
                return false;
            }
        }
        /// <summary>
        /// Update ticket status and Insert a new ticket conversation for a ticket
        /// </summary>
        /// <param name="message"></param>
        /// <param name="outputPort"></param>
        /// <returns></returns>
        public async Task<bool> InsertTicketConversationHandle(InsertTicketConversationReq message, IOutputPort<GetTicketConversationResponse> outputPort)
        {
            try
            {
                var getTicketResponse = await _unitOfWork.TicketRepository.UpdateStatusAsync(
                       message.TicketConversation.TicketId,
                       message.TicketConversation.UserId,
                       message.TicketConversation.Status
                    );
                GetTicketConversationResponse ticketConversationResult = await _unitOfWork.TicketConversationRepository.InsertAsync(_mapper.Map<AppTicketConversation>(message.TicketConversation));
                await _unitOfWork.SaveChangesAsync();
                outputPort.Handle(ticketConversationResult);
                return true;
            }
            catch (Exception ex)
            {
                outputPort.Handle(new GetTicketConversationResponse(null, false, $"خطایی رخ داد:{ex.ToString()}"));
                return false;
            }
            finally
            {
                _unitOfWork.Clear();
            }

        }
        /// <summary>
        /// Get ticketConversations by ticketId
        /// </summary>
        /// <param name="message"></param>
        /// <param name="outputPort"></param>
        /// <returns></returns>
        public async Task<bool> GetTicketConversationsHandle(GetTicketConversationReq message, IOutputPort<GetTicketConversationsResponse> outputPort)
        {
            try
            {
                var ticketConversationsResult = await _unitOfWork.TicketConversationRepository.GetByTicketIdAsync(
                    message.TicketId
                    );
                outputPort.Handle(ticketConversationsResult);
                return true;
            }
            catch (Exception ex)
            {
                outputPort.Handle(new GetTicketConversationsResponse(null, false, $"خطایی رخ داد:{ex.ToString()}"));
                return false;
            }
        }

    }

}

