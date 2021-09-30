using System;
using DoctorWho.web.models;
using FluentValidation;

namespace DoctorWho.web.ValidationAttrbuite
{
    public class EpsoideValidator : AbstractValidator<EpisodeForCreationDto>
    {
        public EpsoideValidator()
        {
            RuleFor(Ep => Ep.SeriesNumber).Must(x => x.ToString().Length == 10).WithMessage("SeriesNumber Should be 10 character long");
            RuleFor(Ep => Ep.EpisodeNumber).GreaterThan(0).WithMessage("EpisodeNumber Should be greater than 0");
            
        }
    }
}
