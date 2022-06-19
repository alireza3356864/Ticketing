using Autofac;
using MazaNetCOreFw.TicketingService.Contracts;
using MazaNetCOreFw.TicketingService.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingService.Module
{
    public class TicketingServiceModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<RootTicketingService>().As<IRootTicketingService>().InstancePerLifetimeScope();
        }
    }
}
