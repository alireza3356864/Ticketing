using MazaNetCOreFw.BaseDomain.Common;
using MazaNetCOreFw.Common.Classes;
using MazaNetCOreFw.TicketingDomain.Dto.Responses;
using MazaNetCOreFw.TicketingDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MazaNetCOreFw.TicketingPersistence.Repository.Interfaces
{
    public interface ITopicRepository
    {
        Task<BaseResponse> InsertAsync(AppTopic topic, CancellationToken cancellationToken = default);
        Task<BaseResponse> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<BaseResponse> UpdateAsync(AppTopic topic, CancellationToken cancellationToken = default);
        Task<TopicsResponse> GetAllAsync(
            SectionType? sectionType=null,
            Guid? sectionId = null,
            string userId = null,
            bool active = true,
            bool delete = true,
            CancellationToken cancellationToken = default);

    }
}
