using AutoMapper;
using MazaNetCOreFw.PAProxyPersistence.Database;
using MazaNetCOreFw.TicketingPersistence.Contracts;
using MazaNetCOreFw.TicketingPersistence.Database;
using MazaNetCOreFw.TicketingPersistence.Repository.Implementations;
using MazaNetCOreFw.TicketingPersistence.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MazaNetCOreFw.TicketingPersistence.Implementations
{
    public class TicketingUnitOfWork : ITicketingUnitOfWork
    {
        private  TicketingDbContext _dbContext;
        private readonly IMapper _mapper;

        public TicketingUnitOfWork(IMapper mapper,
                               TicketingDbContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public ICodeSequenceRepository CodeSequenceRepository => new CodeSequenceRepository(_mapper, _dbContext);
        public ITicketConversationRepository TicketConversationRepository => new TicketConversationRepository(_mapper, _dbContext);
        public ITicketRepository TicketRepository => new TicketRepository(_mapper, _dbContext);
        public ITopicRepository TopicRepository => new TopicRepository(_mapper, _dbContext);



        public async Task<bool> SaveChangesAsync()
        {
            if (_dbContext.ChangeTracker.HasChanges() == false)
                return true;
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public void Clear()
        {
            _dbContext.Dispose();
            _dbContext = new TicketingDbContextFactory().Create();
        }
    }
}
