using MazaNetCOreFw.BaseDomain;
using MazaNetCOreFw.TicketingDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MazaNetCOreFw.DummyPersistence.Database.EntityConfigurations;

namespace MazaNetCOreFw.TicketingPersistence.Database
{
    public class TicketingDbContext:DbContext
    {

        public TicketingDbContext( DbContextOptions<TicketingDbContext> options) : base(options)
        {
           
        }

        public DbSet<AppCodeSequence> CodeSequences { get; set; }
        public DbSet<AppTicket> Tickets { get; set; }
        public DbSet<AppTicketConversation> TicketConversations { get; set; }
        public DbSet<AppTicketRaiser> TicketRaisers { get; set; }
        public DbSet<AppTopic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppCodeSequenceConfigurations).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppTicketConfigurations).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppTicketConversationConfigurations).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppTicketRaiserConfigurations).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppTopicConfigurations).Assembly);

        }

        protected void AddAuditInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.Now;
                }
                ((BaseEntity)entry.Entity).Modified = DateTime.Now;
            }
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            AddAuditInfo();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override int SaveChanges()
        {
            AddAuditInfo();
            return base.SaveChanges();
        }


    }
    

}
