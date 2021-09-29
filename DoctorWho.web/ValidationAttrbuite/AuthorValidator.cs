using System;
using EF_DoctorWho.Db;
using FluentValidation;

namespace DoctorWho.web.ValidationAttrbuite
{
    public class AuthorValidator : AbstractValidator<tblAuthor>
    {
        public AuthorValidator()
        {
            RuleFor(Author => Author.AuthorName).NotNull();
        }
    }
}
