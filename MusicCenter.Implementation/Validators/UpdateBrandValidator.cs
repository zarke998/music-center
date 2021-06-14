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
    public class UpdateBrandValidator : AbstractValidator<UpdateBrandDto>
    {
        public UpdateBrandValidator(MusicCenterDbContext context)
        {
            RuleFor(dto => dto.Id)
                .Must(id => context.Brands.Any(b => b.Id == id))
                .WithMessage("Brand with given id does not exist")
                .DependentRules(() =>
                {
                    RuleFor(dto => dto.Name)
                        .NotEmpty()
                        .WithMessage("Brand name must not be empty")
                        .Must((dto, name) => !context.Brands.Any(b => b.Id != dto.Id && b.Name.ToLower() == name.ToLower()))
                        .WithMessage("Brand name must be unique");
                });
        }
    }
}
