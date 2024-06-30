using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory()));
            configurationManager.AddJsonFile("appsettings.json");
            services.AddDbContext<HRSDbContext>(options => options.UseSqlServer(configurationManager.GetConnectionString("DefaultConnection")));
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IAllergyRepository, AllergyRepository>();
            services.AddScoped<ITitleRepository, TitleRepository>();
            services.AddScoped<IClinicRepository, ClinicRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<INoWorkHourRepository, NoWorkHourRepository>();
            services.AddScoped<IDoctorNoWorkHourRepository, DoctorNoWorkHourRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IBlockRepository, BlockRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IFloorRepository, FloorRepository>();
            services.AddScoped<IOfficeLocationRepository, OfficeLocationRepository>();
            services.AddScoped<IWorkingTimeRepository, WorkingTimeRepository>();
            services.AddScoped<IFAQRepository, FAQRepository>();


            return services;
        }

    }
}
