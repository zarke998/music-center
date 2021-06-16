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
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderDto>
    {
        public UpdateOrderValidator(MusicCenterDbContext context)
        {
            RuleFor(dto => dto.Id)
                .Must(id => context.Orders.Any(o => o.Id == id))
                .WithMessage("Order with id {PropertyValue} does not exist")
                .DependentRules(() =>
                {
                    RuleFor(dto => dto.ShippingAdress)
                        .NotEmpty()
                        .WithMessage("Address must not be empty");

                    RuleFor(dto => dto.UserId)
                        .Must(userId => context.Users.Any(u => u.Id == userId))
                        .WithMessage("User with id {PropertyValue} not found");
                });
            
        }
    }
}
