using Application.Features.Appointments.Rules;
using Application.Services.DoctorService;
using Application.Services.EmailService;
using Application.Services.UserService;
using Application.Services.WorkingTimeService;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using FluentValidation;
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
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));

            });

            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IWorkingTimeService, WorkingTimeManager>();
            services.AddScoped<IDoctorService, DoctorManager>();

            var sendGridApiKey = "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";
            var fromEmail = "noreply-hrs@ahmetyuksel.com";
            
            var sendGridApiKeyFeedbackUser = "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";
            var fromEmailFeedbackUser = "iletisim-hrs@ahmetyuksel.com";

            services.AddScoped<IEmailService>(provider => 
                new EmailService(sendGridApiKey, fromEmail, sendGridApiKeyFeedbackUser, fromEmailFeedbackUser));

            return services;
        }

        public static IServiceCollection AddSubClassesOfType(
       this IServiceCollection services,
       Assembly assembly,
       Type type,
       Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
   )
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
                if (addWithLifeCycle == null)
                    services.AddScoped(item);
                else
                    addWithLifeCycle(services, type);
            return services;
        }

    }
}
