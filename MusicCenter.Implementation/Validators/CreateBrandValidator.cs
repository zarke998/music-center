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
    public class CreateBrandValidator : AbstractValidator<CreateBrandDto>
    {
        public CreateBrandValidator(MusicCenterDbContext context)
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .WithMessage("Brand name must not be empty")
                .Must(name => !context.Brands.Any(b => b.Name.ToLower() == name.ToLower()))
                .WithMessage("Brand name must be unique");
        }
    }
}
