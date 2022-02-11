using Application.Features.Auths.Rules;
using Application.Features.Brands.Rules;
using Application.Features.Cars.Rules;
using Application.Features.Colors.Rules;
using Application.Features.CorporateCustomers.Rules;
using Application.Features.Fuels.Rules;
using Application.Features.IndividualCustomers.Rules;
using Application.Features.Invoices.Rules;
using Application.Features.Maintenances.Rules;
using Application.Features.Rentals.Rules;
using Application.Features.Transmissions.Rules;
using Application.Services.Auths;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Validation;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.Mailing;
using Core.Mailing.MailkitImplementations;
using Core.Security.Jwt;
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
            services.AddScoped<TransmissionBusienessRules>();
            services.AddScoped<FuelBusienessRules>();
            services.AddScoped<CarBusienessRules>();
            services.AddScoped<RentalBusienessRules>();
            services.AddScoped<MaintenanceBusienessRules>();
            services.AddScoped<IndividualCustomerBusienessRules>();
            services.AddScoped<CorporateCustomerBusienessRules>();
            services.AddScoped<InvoiceBusienessRules>();
            services.AddScoped<AuthBusienessRules>();

            services.AddScoped<IAuthService, AuthManager>();
            services.AddSingleton<ITokenHelper, JwtHelper>();
            services.AddSingleton<IMailService, MailkitMailService>();
            services.AddSingleton<LoggerServiceBase, FileLogger>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            return services;
        }
    }
}
