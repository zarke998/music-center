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
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator(MusicCenterDbContext context)
        {
            RuleFor(dto => dto.Id)
                .Must(id => context.Products.Any(p => p.Id == id))
                .WithMessage("Product with given id does not exist")
                .DependentRules(() =>
                {
                    RuleFor(dto => dto.Name)
                        .Must((dto, name) => !context.Products.Any(p => p.Id != dto.Id && p.Name.ToLower() == name.ToLower()))
                        .WithMessage("Product name must be unique.")
                        .When(dto => !String.IsNullOrEmpty(dto.Name));

                    RuleFor(dto => dto.Price)
                        .GreaterThanOrEqualTo(0M)
                        .WithMessage("Price must be positive number.")
                        .When(dto => dto.Price.HasValue);

                    RuleFor(dto => dto.Discount)
                        .InclusiveBetween(0, 99)
                        .WithMessage("Discount must be between 0 and 99 percent.")
                        .When(dto => dto.Discount.HasValue);

                    RuleFor(dto => dto.BrandId)
                        .Must(brandId => context.Brands.Any(b => b.Id == brandId))
                        .WithMessage("Brand with specified id does not exist.")
                        .When(dto => dto.BrandId.HasValue);
                });
            
        }
    }
}
