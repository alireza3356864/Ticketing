using FluentValidation;
using MazaNetCOreFw.TicketingInfrastructure.ViewModels.Requests.Topics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingInfrastructure.ViewModels.Validations.Topics
{
    public class InsertCodeSequenceRequestValidator : AbstractValidator<InsertCodeSequenceRequest>
    {
        public InsertCodeSequenceRequestValidator()
        {
            RuleFor(m => m.Prefix).NotNull().NotEmpty()
                .WithMessage(x => "پیشوند نمی تواند خالی باشد")
                .MaximumLength(10)
                .WithMessage(x => "پیشوند نمی تواند بیشتر از 10 کاراکتر باشد");

            RuleFor(m => m.Sequence).NotNull().NotEmpty()
                 .WithMessage(x => "شماره نمی تواند خالی باشد");

            
        }
    }
}
