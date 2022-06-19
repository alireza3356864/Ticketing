using System;
using MazaNetCOreFw.TicketingPersistence.Database;
using MazaNetCOreFw.SharedPersistence.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MazaNetCOreFw.PAProxyPersistence.Database
{
    public class TicketingDbContextFactory : DesignTimeDbContextFactoryBase<TicketingDbContext>
    {
        protected override TicketingDbContext CreateNewInstance(DbContextOptions<TicketingDbContext> options)
        {
            
            return new TicketingDbContext(options);
        }

        protected override string GetMyConnectionString(IConfigurationRoot config)
        {
            //LOCAL SYSTEM - PUBLISH
            var conStrName = "TicketingConnectionStr";

            var connstr = config.GetConnectionString(conStrName);
            if (string.IsNullOrWhiteSpace(connstr))
            {
                throw new InvalidOperationException($"Could not find any connection string named '{conStrName}' in config file !!!");
            }
            return connstr;
        }
    }
}
