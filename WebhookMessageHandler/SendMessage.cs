using AutoMapper;
using MazaNetCOreFw.PAProxyPersistence.Database;
using MazaNetCOreFw.TicketingPersistence.Database;
using MazaNetCOreFw.TicketingPersistence.Implementations;
using MazaNetCOreFw.TicketingPersistence.Mapping;
using MazaNetCOreFw.TicketingService.Implementations;
using MazaNetCOreFw.TicketingService.Presenters.Topics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace Webhook
{
    public class SendMessage
    {
        private IMapper _mapper => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new TicketingProfile());
        }).CreateMapper();
        
        
        public  async Task InsertTicketTest()
        {

            using (TicketingDbContext dbContext = new TicketingDbContextFactory().Create())
            {
                var unitOfWork = new TicketingUnitOfWork(_mapper, dbContext);
                RootTicketingService rootDummyService = new RootTicketingService(unitOfWork, _mapper);
                TicketPresenter ticketPresenter = new TicketPresenter();

                rootDummyService.CustomErrorEvent += () =>
                {
                    var botClient = new TelegramBotClient("5448721328:AAHCVloFEcU9RssNjAcxDbNGM_TQUW3hLgY");
                    using var cts = new CancellationTokenSource();
                    botClient.SendTextMessageAsync(229209448, "Insert message Is successful");
                };
            }
        }
    }
}
