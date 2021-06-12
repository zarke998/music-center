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
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator(MusicCenterDbContext context)
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .WithMessage("Product name must not be empty.").DependentRules(() =>
                {
                    RuleFor(dto => dto.Name)
                    .Must(name => !context.Products.Any(p => p.Name == name))
                    .WithMessage("Product name must be unique.");
                });

            RuleFor(dto => dto.Price)
                .GreaterThanOrEqualTo(0M)
                .WithMessage("Price must be positive number.");

            RuleFor(dto => dto.Discount)
                .InclusiveBetween(0, 99)
                .WithMessage("Discount must be between 0 and 99 percent.");

            RuleFor(dto => dto.BrandId)
                .Must(brandId => context.Brands.Any(b => b.Id == brandId))
                .WithMessage("Brand with specified id does not exist.");

            RuleFor(dto => dto.Categories)
                .Must(cats =>
                {
                    var distinctCategories = cats.Distinct();
                    return distinctCategories.Count() == cats.Count;
                })
                .WithMessage("Product categories must be unique.")
                .When(dto => dto.Categories != null && dto.Categories.Count > 0, ApplyConditionTo.CurrentValidator)
                .DependentRules(() =>
                {
                    RuleForEach(dto => dto.Categories)
                        .Must(categoryId => context.Categories.Any(c => c.Id == categoryId))
                        .WithMessage((dto, id) => $"Category {id} does not exist.");
                });
        }
    }
}
