using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Commands.CreateIndividualCustomer
{
    public class CreateIndividualCustomerValidator:AbstractValidator<CreateIndividualCustomerCommand>
    {
        public CreateIndividualCustomerValidator()
        {
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.NationalityId).NotEmpty();
            RuleFor(c => c.NationalityId).MinimumLength(11);
        }
    }
}
