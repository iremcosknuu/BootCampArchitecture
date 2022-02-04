﻿using Application.Features.Brands.Rules;
using Application.Features.Cars.Rules;
using Application.Features.Colors.Rules;
using Application.Features.Maintenances.Rules;
using Application.Features.Rentals.Rules;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<BrandBusinessRules>();
            services.AddScoped<ColorBusienessRules>();
            services.AddScoped<ModelBusienesRules>();
            services.AddScoped<CarBusienessRules>();
            services.AddScoped<RentalBusienessRules>();
            services.AddScoped<MaintenanceBusienessRules>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }
    }
}
