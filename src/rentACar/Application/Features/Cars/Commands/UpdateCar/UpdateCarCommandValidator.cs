using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.UpdateCar
{
    public class UpdateCarCommandValidator:AbstractValidator<UpdateCarCommand>
    {
        public UpdateCarCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.Plate).NotEmpty();
            RuleFor(c => c.ModelId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ColorId).GreaterThan(0);
            RuleFor(c => c.ModelId).GreaterThan(0);
            RuleFor(c => c.Plate).Length(6, 9);
            RuleFor(c => c.Plate).Must(StartWithNumber);
            RuleFor(c => c.ModelYear).Must(BeAfter2000).WithMessage("Eklemek istediğiniz araçlar 2000 öncesi olamaz!");
        }

        private bool BeAfter2000(short modelYear)
        {
            return modelYear >= 2000;
        }

        private bool StartWithNumber(string plate)
        {
            var firstTwo = plate.Substring(0, 2);
            int tmp = 0;
            bool result = int.TryParse(firstTwo, out tmp);
            return result;
        }
    }
}
