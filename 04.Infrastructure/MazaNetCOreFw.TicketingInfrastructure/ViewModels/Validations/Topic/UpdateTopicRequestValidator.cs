using FluentValidation;
using MazaNetCOreFw.TicketingInfrastructure.ViewModels.Requests.Topics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingInfrastructure.ViewModels.Validations.Topics
{
    public class UpdateTopicRequestValidator : AbstractValidator<UpdateTopicRequest>
    {
        public UpdateTopicRequestValidator()
        {
            RuleFor(m => m.Id).NotNull().NotEmpty()
                 .WithMessage(x => "اطلاعات وارد شده صحیح نیست");

            RuleFor(m => m.Title).NotNull().NotEmpty()
                .WithMessage(x => "عنوان نمی تواند خالی باشد");

            RuleFor(m => m.Title).MinimumLength(3)
               .WithMessage(x => "عنوان نمی تواند کمتر از 3 کاراکتر باشد")
                .MaximumLength(200)
                .WithMessage(x => "عنوان نمی تواند بیشتر از 200 کاراکتر باشد");

            RuleFor(x => x)
               .Must(x => string.IsNullOrEmpty(x.UserId) ||
               (!string.IsNullOrEmpty(x.UserId) &&
               x.SectionId != null &&
               !x.SectionId.Equals(Guid.Empty)))
               .WithMessage("اطلاعات بخش کاربر به صورت ناقص وارد شده است");

        }
    }
}
