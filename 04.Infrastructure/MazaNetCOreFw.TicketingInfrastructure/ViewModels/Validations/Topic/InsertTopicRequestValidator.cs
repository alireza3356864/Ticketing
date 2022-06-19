using FluentValidation;
using MazaNetCOreFw.TicketingInfrastructure.ViewModels.Requests.Topics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingInfrastructure.ViewModels.Validations.Topics
{
    public class InsertTopicRequestValidator : AbstractValidator<InsertTopicRequest>
    {
        public InsertTopicRequestValidator()
        {
            RuleFor(m => m.Title).NotNull().NotEmpty()
                .WithMessage(x => "عنوان نمی تواند خالی باشد");

            RuleFor(x => x)
               .Must(x => string.IsNullOrEmpty(x.UserId) ||
               (!string.IsNullOrEmpty(x.UserId) &&
               x.SectionId != null &&
               !x.SectionId.Equals(Guid.Empty)))
               .WithMessage("اطلاعات بخش کاربر به صورت ناقص وارد شده است");

        }
    }
}