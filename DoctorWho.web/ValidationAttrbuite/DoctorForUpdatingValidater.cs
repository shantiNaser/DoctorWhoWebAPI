using System;
using DoctorWho.web.models;
using FluentValidation;

namespace DoctorWho.web.ValidationAttrbuite.DoctorValidater
{
    public class DoctorForUpdatingValidator : AbstractValidator<DoctorForUpdatingDto>
    {
        public DoctorForUpdatingValidator()
        {
            RuleFor(Dr => Dr.DoctorName).NotNull().WithMessage("you should fill out DoctorName");
            RuleFor(Dr => Dr.DoctorNumber).NotNull().WithMessage("you should fill out the DoctorNumber");

            RuleFor(o => o.LastEpisodeDate)
                    .Null()
                    .When(o => o.FirstEpisodeDate == null)
                    .WithMessage("LastEpisodeDate must be null when FirstEpisodeDate has No value");

            RuleFor(Dr => Dr.LastEpisodeDate).GreaterThanOrEqualTo(Dr => Dr.FirstEpisodeDate);

        }
    }
}
