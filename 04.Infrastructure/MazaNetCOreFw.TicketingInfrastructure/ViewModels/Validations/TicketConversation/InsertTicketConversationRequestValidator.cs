using FluentValidation;
using MazaNetCOreFw.TicketingInfrastructure.ViewModels.Requests.Topics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingInfrastructure.ViewModels.Validations.Topics
{
    public class InsertTicketConversationRequestValidator : AbstractValidator<InsertTicketConversationRequest>
    {
        public InsertTicketConversationRequestValidator()
        {
            RuleFor(m => m.TicketId).NotNull().NotEmpty()
                .WithMessage(x => "هیچ نظری ثبت نشده است");

            RuleFor(m => m.ParentTicketId).NotNull().NotEmpty()
                .WithMessage(x => "هیچ مکالمه ای وجود ندارد");

            RuleFor(m => m.Status).NotNull().NotEmpty()
                .WithMessage(x => "وضعیت نمی تواند خالی باشد");

            RuleFor(m => m.Body).NotNull().NotEmpty()
                .WithMessage(x => "توضیحات نمی تواند خالی باشد")
                .MinimumLength(10)
                .WithMessage(x => "توضیحات نمی تواند کمتر از 10 کاراکتر باشد");

        }
    }
}