using Application.Features.Appointments.Constants;
using Application.Repositories;
using Application.Services.DoctorService;
using Application.Services.WorkingTimeService;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Application.Features.Appointments.Rules
{
    public class AppointmentBusinessRules : BaseBusinessRules
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IWorkingTimeService _workingTimeService;
        private readonly IDoctorService _doctorService;

        public AppointmentBusinessRules(IAppointmentRepository appointmentRepository, IWorkingTimeService workingTimeService, IDoctorService doctorService)
        {
            _appointmentRepository = appointmentRepository;
            _workingTimeService = workingTimeService;
            _doctorService = doctorService;
        }

        public async Task AppointmentCanNotDuplicatedWhenBooked(int patientId,int doctorId, DateTime dateTime)
        {
            Appointment? appointment = await _appointmentRepository.GetAsync(a => a.PatientId == patientId && a.DoctorId == doctorId  && a.DateTime == dateTime, asNoTracking: true);

            if (appointment is not null)
                throw new BusinessException(AppointmentsMessages.AppointmentHasAlreadyBeenBooked);

        }

        public async Task AppointmentTimeShouldBeValidWhenBooked(int doctorId, DateTime appointmentDateTime)
        {

            WorkingTime workingTime = await _workingTimeService.GetLatestAsync();
            Doctor doctor = await _doctorService.GetDoctorWithNoWorkHoursById(doctorId);

            // Dakikanın 20 dakikalık dilimlere bölünüp bölünmediğini kontrol eder
            bool isValid = (appointmentDateTime.Minute % doctor.Clinic.AppointmentDuration) == 0;
            if (!isValid)
            {
                throw new BusinessException(AppointmentsMessages.AppointmentTimeIsInvalid);
            }

            TimeSpan appointmentTime = appointmentDateTime.TimeOfDay;

            // Randevu zamanının çalışma saatleri içerisinde olup olmadığını kontrol et
            if (appointmentTime < workingTime.StartTime || appointmentTime > workingTime.EndTime)
            {
                throw new BusinessException(AppointmentsMessages.AppointmentTimeIsOutsideWorkingHours);
            }

            // Randevu zamanının mola saatleri içerisinde olup olmadığını kontrol et
            if (appointmentTime >= workingTime.StartBreakTime && appointmentTime <= workingTime.EndBreakTime)
            {
                throw new BusinessException(AppointmentsMessages.AppointmentTimeIsDuringBreakHours);
            }

            // Randevu zamanının doktorun müsait olmadığı zamanlar içerisinde olup olmadığını kontrol et
            foreach (var doctorNoWorkHour in doctor.DoctorNoWorkHours)
            {
                if (appointmentDateTime >= doctorNoWorkHour.NoWorkHour.StartDate && appointmentDateTime <= doctorNoWorkHour.NoWorkHour.EndDate)
                {
                    throw new BusinessException(AppointmentsMessages.AppointmentTimeIsDuringNoWorkHours(doctorNoWorkHour.NoWorkHour.Title));
                }
            }

        }
    }
}
