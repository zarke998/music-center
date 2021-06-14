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
    public class CreateCategoryValidator : AbstractValidator<CategoryDto>
    {
        public CreateCategoryValidator(MusicCenterDbContext context)
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .WithMessage("Category name must not be empty")
                .DependentRules(() =>
                {
                    RuleFor(dto => dto.Name)
                        .Must(name => !context.Categories.Any(c => c.Name.ToLower() == name.ToLower()))
                        .WithMessage("Category name must be unique");
                });
                
        }
    }
}
