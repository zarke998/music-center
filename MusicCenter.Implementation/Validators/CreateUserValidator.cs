using FluentValidation;
using MusicCenter.Application.DTO;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator(MusicCenterDbContext context)
        {
            RuleFor(dto => dto.FirstName)
                .NotEmpty()
                .WithMessage("First name must not be empty");

            RuleFor(dto => dto.LastName)
                .NotEmpty()
                .WithMessage("Last name must not be empty");

            RuleFor(dto => dto.Email)
                .NotEmpty()
                .WithMessage("Email must not be empty")
                .DependentRules(() =>
                {
                    RuleFor(dto => dto.Email)
                        .EmailAddress()
                        .WithMessage("Email is not in correct format.")
                        .Must(email => !context.Users.Any(u => u.Email == email))
                        .WithMessage("Email must be unique.");
                });

            RuleFor(dto => dto.Password)
                .NotEmpty()
                .WithMessage("Password must not be empty")
                .DependentRules(() =>
                {
                    RuleFor(dto => dto.Password)
                        .Matches(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$")
                        .WithMessage("Password must be minimum 8 chars, and containt at least one letter and number.");
                });
        }
    }
}
