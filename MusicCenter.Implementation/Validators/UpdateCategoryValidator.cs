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
    public class UpdateCategoryValidator : AbstractValidator<CategoryDto>
    {
        public UpdateCategoryValidator(MusicCenterDbContext context)
        {
            RuleFor(dto => dto.Id)
                .Must(id => context.Categories.Any(c => c.Id == id))
                .WithMessage("Category with given id does not exist")
                .DependentRules(() =>
                {
                    RuleFor(dto => dto.Name)
                        .NotEmpty()
                        .WithMessage("Category name must not be empty")
                        .Must((dto, name) => !context.Categories.Any(c => c.Id != dto.Id && c.Name.ToLower() == name.ToLower()))
                        .WithMessage("Category name must be unique");
                });
        }
    }
}
