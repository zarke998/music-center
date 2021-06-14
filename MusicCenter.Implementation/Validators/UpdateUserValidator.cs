using FluentValidation;
using MusicCenter.Application;
using MusicCenter.Application.DTO;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator(MusicCenterDbContext context)
        {
            RuleFor(dto => dto.Id)
                .Must(id => context.Users.Any(p => p.Id == id))
                .WithMessage("User with given id does not exist")
                .DependentRules(() =>
                {                     
                    RuleFor(dto => dto.Email)
                        .Must((dto, email) => !context.Users.Any(u => u.Id != dto.Id && u.Email == dto.Email))
                        .WithMessage("Email must be unique")
                        .When(dto => !String.IsNullOrEmpty(dto.Email));

                    RuleFor(dto => dto.Password)
                        .Matches(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$")
                        .WithMessage("Password must be minimum 8 chars, and containt at least one letter and number.")
                        .When(dto => !String.IsNullOrEmpty(dto.Password));
                });
            
        }
    }
}
