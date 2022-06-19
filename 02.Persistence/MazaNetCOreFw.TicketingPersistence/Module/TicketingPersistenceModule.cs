using Autofac;
using MazaNetCOreFw.TicketingPersistence.Contracts;
using MazaNetCOreFw.TicketingPersistence.Implementations;
using MazaNetCOreFw.TicketingPersistence.Repository.Implementations;
using MazaNetCOreFw.TicketingPersistence.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingPersistence.Module
{
    public class TicketingPersistenceModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
           builder.RegisterType<TicketingUnitOfWork>().As<ITicketingUnitOfWork>().InstancePerLifetimeScope();
           builder.RegisterType<CodeSequenceRepository>().As<ICodeSequenceRepository>().InstancePerLifetimeScope();
           builder.RegisterType<TicketConversationRepository>().As<ITicketConversationRepository>().InstancePerLifetimeScope();
           builder.RegisterType<TicketRepository>().As<ITicketRepository>().InstancePerLifetimeScope();
           builder.RegisterType<TopicRepository>().As<ITopicRepository>().InstancePerLifetimeScope();

        }
    }
}
