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
    public class CreateUserCartProductValidator : AbstractValidator<CreateUserCartProductDto>
    {
        public CreateUserCartProductValidator(MusicCenterDbContext context)
        {
            RuleFor(dto => dto)
                .Must((dto) =>
                {
                    return !context.UserCartProducts.Any(ucp => ucp.UserId == dto.UserId && ucp.ProductId == dto.ProductId);
                })
                .WithMessage("Pair UserId-ProductId already exists in database")
                .WithName("Pair UserId-ProductId")
                .DependentRules(() =>
                {
                    RuleFor(dto => dto.UserId)
                        .Must(id => context.Users.Any(u => u.Id == id))
                        .WithMessage("User with id {PropertyValue} does not exist.");

                    RuleFor(dto => dto.ProductId)
                        .Must(id => context.Products.Any(p => p.Id == id))
                        .WithMessage("Product with id {PropertyValue} does not exist.")
                        .DependentRules(() =>
                        {
                            RuleFor(dto => dto.Quantity)
                                .Must((dto, quantity) =>
                                {
                                    var productQuantity = context.Products.Find(dto.ProductId).Quantity;
                                    return quantity <= productQuantity;

                                })
                                .WithMessage("Quantity {PropertyValue} exceeds available product quantity.");
                        });
                });
        }
    }
}
