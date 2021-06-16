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
    public class UpdateOrderProductValidator : AbstractValidator<UpdateOrderProductDto>
    {
        public UpdateOrderProductValidator(MusicCenterDbContext context)
        {
            RuleFor(dto => dto.Id)
                .Must(id => context.OrderProducts.Any(op => op.Id == id))
                .WithMessage("Order product with id {PropertyValue} does not exist")
                .DependentRules(() =>
                {
                    RuleFor(dto => dto.Price)
                        .GreaterThanOrEqualTo(0)
                        .WithMessage("Price {PropertyValue} must be greater than or equal to 0")
                        .When(dto => dto.Price != null);

                    RuleFor(dto => dto.Quantity)
                        .GreaterThan(0)
                        .WithMessage("Quantity {PropertyValue} must be greater than 0")
                        .When(dto => dto.Quantity != null);

                    RuleFor(dto => dto.OrderId)
                        .Must(orderId => context.Orders.Any(o => o.Id == orderId))
                        .WithMessage("OrderId {PropertyValue} does not exist")
                        .When(dto => dto.OrderId != null);
                });
        }
    }
}
