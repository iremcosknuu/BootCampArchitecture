using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.CreateCar
{
    public class CreateCarCommandValidator: AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {
            RuleFor(c => c.Plate).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ModelId).NotEmpty();
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.ModelYear).Must(BeAfter2015).WithMessage("Eklemek istediğiniz araçlar 2015 öncesi olamaz!");

        }

        private bool BeAfter2015(int modelYear)
        {
            return modelYear >= 2015;
        }

    }
}
