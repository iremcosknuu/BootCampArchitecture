using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Commands.UpdateTransmission
{
    public class UpdateTransmissionCommandValidator:AbstractValidator<UpdateTransmissionCommand>
    {
        public UpdateTransmissionCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
