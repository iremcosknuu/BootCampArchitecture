using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Commands.CreateTransmission
{
    public class CreateTransmissionCommandValidator:AbstractValidator<CreateTransmissionCommand>
    {
        public CreateTransmissionCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);
        }
    }
}
