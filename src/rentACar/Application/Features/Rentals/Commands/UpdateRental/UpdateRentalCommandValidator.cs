using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rentals.Commands.UpdateRental
{
    public class UpdateRentalCommandValidator:AbstractValidator<UpdateRentalCommand>
    {
        public UpdateRentalCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.RentKilometer).NotEmpty();
            RuleFor(c => c.RentDate).NotEmpty();
            RuleFor(c => c.CarId).NotEmpty();
        }
    }
}
