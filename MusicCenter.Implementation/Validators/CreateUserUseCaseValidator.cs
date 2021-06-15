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
    public class CreateUserUseCaseValidator : AbstractValidator<CreateUserUseCaseDto>
    {
        public CreateUserUseCaseValidator(MusicCenterDbContext context)
        {
            RuleFor(dto => dto.UserId)
                .Must(id => context.Users.Any(u => u.Id == id))
                .WithMessage("User with id {PropertyValue} doesn not exist")
                .DependentRules(() =>
                {
                    RuleFor(dto => dto)
                    .Must((dto) => !context.UserUseCases.Any(uc => uc.UserId == dto.UserId && uc.UseCaseId == dto.UseCaseId))
                    .WithMessage("This pair of user id and use case id already exists in database.")
                    .WithName("Pair UserId-UseCaseId");
                });
        }
    }
}
