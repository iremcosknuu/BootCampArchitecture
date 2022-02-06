﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands.UpdateModel
{
    public class UpdateModelCommandValidator:AbstractValidator<UpdateModelCommand>
    {
        public UpdateModelCommandValidator()
        {
            RuleFor(m => m.id).NotEmpty();
            RuleFor(m => m.ImageUrl).NotEmpty();
            RuleFor(m => m.DailyPrice).NotEmpty();
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.BrandId).NotEmpty();
            RuleFor(m => m.TransmissionId).NotEmpty();
            RuleFor(m => m.FuelId).NotEmpty();

            RuleFor(m => m.ImageUrl).Must(ValidFormat).WithMessage("Resim formatı uygun değil.");

            RuleFor(m => m.FuelId).GreaterThan(0);
            RuleFor(m => m.TransmissionId).GreaterThan(0);
            RuleFor(m => m.BrandId).GreaterThan(0);

            RuleFor(m => m.DailyPrice).GreaterThanOrEqualTo(200);
            RuleFor(m => m.DailyPrice).LessThanOrEqualTo(1000);
        }


        private bool ValidFormat(string url)
        {
            return url.EndsWith(".png") || url.EndsWith(".jpg") || url.EndsWith(".jpeg");
        }
    }
    }
}
