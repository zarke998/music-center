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
    public class CreateOrderProductValidator : AbstractValidator<CreateOrderProductDto>
    {
        public CreateOrderProductValidator(MusicCenterDbContext context)
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .WithMessage("Product name must not be empty must not be empty")
                .DependentRules(() =>
                {
                    RuleFor(dto => dto.Name)
                        .Must((dto, name) => !context.OrderProducts.Any(op => op.OrderId == dto.OrderId && op.Name == name))
                        .WithMessage("Product name already added as an item to this order");
                });

            RuleFor(dto => dto.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price {PropertyValue} must be greater than or equal to 0");

            RuleFor(dto => dto.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity {PropertyValue} must be greater than 0");

            RuleFor(dto => dto.OrderId)
                .Must(orderId => context.Orders.Any(o => o.Id == orderId))
                .WithMessage("OrderId {PropertyValue} does not exist");
        }
    }
}
