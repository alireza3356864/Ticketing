using FluentValidation;
using System;
using MazaNetCOreFw.TicketingInfrastructure.ViewModels.Requests.Topics;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingInfrastructure.ViewModels.Validations.Topics
{
    public class DeleteTopicRequestValidator : AbstractValidator<DeleteTopicRequest>
    {
        public DeleteTopicRequestValidator()
        {
            RuleFor(m => m.Id).NotNull().NotEmpty()
                .WithMessage(x => "لطفا شناسه موضوع را وارد نمایید");

        }
    }
}
