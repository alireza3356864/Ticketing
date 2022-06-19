using FluentValidation;
using MazaNetCOreFw.TicketingInfrastructure.ViewModels.Requests.Topics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingInfrastructure.ViewModels.Validations.Topics
{
    public class GetTicketConversationRequestValidator : AbstractValidator<GetTicketConversationsRequest>
    {
        public GetTicketConversationRequestValidator()
        {
            RuleFor(m => m.TicketId).NotNull().NotEmpty()
                .WithMessage(x => "لطفا شناسه تیکت را وارد فرمایید");
        }
    }
}