using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MazaNetCOreFw.TicketingService.Presenters
{
    public static class TicketingPresentersConfig
    {
        public static void AddInfraStorePresenters(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Presenter")).SingleInstance();
        }
    }
}
