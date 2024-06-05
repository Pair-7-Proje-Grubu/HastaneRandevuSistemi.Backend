using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class PersistenceServiceRegistration
    {
       public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<HRSDbContext>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IAllergyRepository, AllergyRepository>();
            services.AddScoped<ITitleRepository, TitleRepository>();
            services.AddScoped<IClinicRepository, ClinicRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();


            return services;
        }
        
    }
}
