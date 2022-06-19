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
    public interface ICodeSequenceRepository
    {
        Task<GenerateCodeResponse>GenerateCodeAsync(SectionType? sectionType = null, Guid? sectionId = null, string userId = null, CancellationToken cancellationToken = default);
        Task<BaseResponse> InsertAsync(AppCodeSequence codeSequence, CancellationToken cancellationToken = default);


    }
}
