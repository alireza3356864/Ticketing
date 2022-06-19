using AutoMapper;
using MazaNetCOreFw.BaseDomain.Common;
using MazaNetCOreFw.Common.Classes;
using MazaNetCOreFw.TicketingDomain.Dto.Entities;
using MazaNetCOreFw.TicketingDomain.Dto.Responses;
using MazaNetCOreFw.TicketingDomain.Entities;
using MazaNetCOreFw.TicketingPersistence.Database;
using MazaNetCOreFw.TicketingPersistence.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MazaNetCOreFw.TicketingPersistence.Repository.Implementations
{
    public class TopicRepository : ITopicRepository
    {
        private readonly IMapper _mapper;
        private readonly TicketingDbContext _dbContext;
        public TopicRepository(IMapper mapper, TicketingDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        /// <summary>
        /// Delete a topic
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BaseResponse> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var appTopic=await _dbContext.Topics.FindAsync(id);
                appTopic.Active = false;
                appTopic.Deleted = true;
                return new BaseResponse(null, true, "عملیات با موفقیت انجام شد");

            }
            catch (Exception ex)
            {
                return new BaseResponse(null, false, $"خطایی رخ داد:{ex.ToString()}");
            }
        }
        /// <summary>
        /// get all topics
        /// </summary>
        /// <param name="sectionType"></param>
        /// <param name="sectionId"></param>
        /// <param name="userId"></param>
        /// <param name="checkActive"></param>
        /// <param name="checkDeleted"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TopicsResponse> GetAllAsync(SectionType? sectionType=null,
                                                     Guid? sectionId = null,
                                                     string userId = null,
                                                     bool checkActive = true,
                                                     bool checkDeleted = true,
                                                     CancellationToken cancellationToken = default)
        {
            try
            {
                    //topics with sectiontype null are considered as general
                    //if user ask for a specific section type return general topics and that specific sectiontypes
                    //if user wants all section types he/she should send null for sectiontype
                var appTopics = await _dbContext.Topics
                 .Where(x => (sectionType == null || x.SectionType == null || x.SectionType.Equals(sectionType))
                          && (sectionId==null || x.SectionId == null || x.SectionId.Equals(sectionId))
                          && (userId == null ||x.UserId == null || x.UserId.Equals(userId))
                          && (!checkActive || x.Active) 
                          && (!checkDeleted || !x.Deleted))
                .ToListAsync(cancellationToken);
                return new TopicsResponse(_mapper.Map<List<Topic>>(appTopics), true, "عملیات با موفقیت انجام شد");
            }
            catch (Exception ex)
            {

                return new TopicsResponse(null, false, $"خطایی رخ داد:{ex.ToString()}");
            }
        }
        /// <summary>
        /// insert a new topic
        /// </summary>
        /// <param name="Topic"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BaseResponse> InsertAsync(AppTopic Topic, CancellationToken cancellationToken = default)
        {
            try
            {
                await _dbContext.Topics.AddAsync(Topic, cancellationToken);
                return new BaseResponse(null, true, "عملیات با موفقیت انجام شد");

            }
            catch (Exception ex)
            {
                return new BaseResponse(null, false, $"خطایی رخ داد:{ex.ToString()}");
            }
        }

        /// <summary>
        /// Update a Topic
        /// </summary>
        /// <param name="Topic"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BaseResponse> UpdateAsync(AppTopic Topic, CancellationToken cancellationToken = default)
        {
            try
            {
                var appTopicUpdate = await _dbContext.Topics.FindAsync(Topic.Id);

                appTopicUpdate.Modified = DateTime.Now;
                appTopicUpdate.Title = Topic.Title;
                appTopicUpdate.SectionType = Topic.SectionType;
                appTopicUpdate.SectionId = Topic.SectionId;
                appTopicUpdate.SectionName = Topic.SectionName;
                appTopicUpdate.UserId = Topic.UserId;
                appTopicUpdate.UserName = Topic.UserName;

                return new BaseResponse(null, true, "عملیات با موفقیت انجام شد");

            }
            catch (Exception ex)
            {
                return new BaseResponse(null, false, $"خطایی رخ داد:{ex.ToString()}");
            }
        }
    }
}
