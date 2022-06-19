using AutoMapper;
using MazaNetCOreFw.Common.Classes;
using MazaNetCOreFw.TicketingDomain.Dto.Entities;
using MazaNetCOreFw.TicketingDomain.Dto.Responses;
using MazaNetCOreFw.TicketingPersistence.Database;
using MazaNetCOreFw.TicketingPersistence.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using MazaNetCOreFw.BaseDomain.Common;
using MazaNetCOreFw.TicketingDomain.Entities;
using MazaNetCOreFw.Common.Utils.Dates;

namespace MazaNetCOreFw.TicketingPersistence.Repository.Implementations
{
    public class CodeSequenceRepository: ICodeSequenceRepository
    {
        private readonly IMapper _mapper;
        private readonly TicketingDbContext _dbContext;
        public CodeSequenceRepository(IMapper mapper, TicketingDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        /// <summary>
        /// Generate a new ticket code based on year and where it raised
        /// </summary>
        /// <param name="sectionType"></param>
        /// <param name="sectionId"></param>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GenerateCodeResponse> GenerateCodeAsync(SectionType? sectionType = null,
                                                                  Guid? sectionId = null,
                                                                  string userId = null,
                                                                  CancellationToken cancellationToken = default)
        {
            try
            {
                int persianDate= int.Parse(DateTime.Now.ToPersianDate("yyyy"));
                var appcodes = await _dbContext.CodeSequences.
                             Where(x =>
                             (x.SectionType == null || x.SectionType.Equals(sectionType))
                             && (x.SectionId == null || x.SectionId.Equals(sectionId))
                             && (x.UserId == null || x.UserId.Equals(userId))
                             && (x.Year.Equals(persianDate))
                              )
                             .OrderByDescending(x => x.UserId)
                             .ThenByDescending(x => x.SectionId)
                             .ThenByDescending(x => x.SectionType)
                            .FirstOrDefaultAsync();
                if (appcodes is null) {
                    return new GenerateCodeResponse(false, "امکان ساخت تیکت جدید در سال جاری موجود نیست، لطفا با مدیر سیستم تماس حاصل فرمایید");
                }
                var code = $"{appcodes.Prefix}{appcodes.Sequence}";
                appcodes.Sequence += 1;
                return new GenerateCodeResponse(code , true, "عملیات با موفقیت انجام شد");
            }
            catch (Exception ex)
            {

                return new GenerateCodeResponse(null, false, $"خطایی رخ داد:{ex.ToString()}");
            }
        }

       
        /// <summary>
        /// Insert new Code Sequence Generator
        /// </summary>
        /// <param name="codeSequence"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BaseResponse> InsertAsync(AppCodeSequence codeSequence, CancellationToken cancellationToken = default)
        {
            try
            {

                codeSequence.Year = int.Parse(DateTime.Now.ToPersianDate("yyyy"));

                await _dbContext.CodeSequences.AddAsync(codeSequence, cancellationToken);
                return new BaseResponse(null, true, "عملیات با موفقیت انجام شد");

            }
            catch (Exception ex)
            {
                return new BaseResponse(null, false, $"خطایی رخ داد:{ex.ToString()}");
            }
        }
    }
}
