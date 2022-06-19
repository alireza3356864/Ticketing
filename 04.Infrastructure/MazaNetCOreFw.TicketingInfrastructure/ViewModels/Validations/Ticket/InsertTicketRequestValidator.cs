using FluentValidation;
using MazaNetCOreFw.TicketingInfrastructure.ViewModels.Requests.Topics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingInfrastructure.ViewModels.Validations.Topics
{
    public class InsertTicketRequestValidator : AbstractValidator<InsertTicketRequest>
    {
        public InsertTicketRequestValidator()
        {
            RuleFor(m => m.Title).NotNull().NotEmpty()
                .WithMessage(x => "عنوان نمی تواند خالی باشد")
                .MinimumLength(3)
                .WithMessage(x => "عنوان نمی تواند کمتر از 3 کاراکتر باشد")
                .MaximumLength(200)
                .WithMessage(x => "عنوان نمی تواند بیشتر از 200 کاراکتر باشد");

            RuleFor(m => m.Body).NotNull().NotEmpty()
                .WithMessage(x => "توضیحات نمی تواند خالی باشد")
                .MinimumLength(10)
                .WithMessage(x => "توضیحات نمی تواند کمتر از 10 کاراکتر باشد");

            RuleFor(m => m.TopicId).NotNull().NotEmpty()
                .WithMessage(x => "موضوع نمی تواند خالی باشد");

            RuleFor(m => m.Priority).NotNull().NotEmpty()
                .WithMessage(x => "اولویت نمی تواند خالی باشد");

            RuleFor(m => m.SectionType).NotNull().NotEmpty()
                .WithMessage(x => "نوع بخش نمی تواند خالی باشد");

            RuleFor(x => x)
               .Must(x => string.IsNullOrEmpty(x.UserId) ||
               (!string.IsNullOrEmpty(x.UserId) &&
               x.SectionId != null &&
               !x.SectionId.Equals(Guid.Empty) &&
               x.SectionType != null &&
               !x.SectionType.Equals(Guid.Empty)))
               .WithMessage("اطلاعات بخش کاربر به صورت ناقص وارد شده است");

        }
    }
}