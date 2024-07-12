using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Rules
{
    public class AppointmentBusinessRules : BaseBusinessRules
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IWorkingTimeRepository _workingTimeRepository;
        private readonly IDoctorRepository _doctorRepository;

        public AppointmentBusinessRules(IAppointmentRepository appointmentRepository, IWorkingTimeRepository workingTimeRepository, IDoctorRepository doctorRepository)
        {
            _appointmentRepository = appointmentRepository;
            _workingTimeRepository = workingTimeRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task AppointmentCanNotDuplicatedWhenBooked(int patientId,int doctorId, DateTime dateTime)
        {
            Appointment? appointment = await _appointmentRepository.GetAsync(a => a.PatientId == patientId && a.DoctorId == doctorId  && a.DateTime == dateTime, asNoTracking: true);

            if (appointment is not null)
                throw new BusinessException("Bu zamana ait randevu zaten alınmış!");

        }

        public async Task AppointmentTimeShouldBeValidWhenBooked(int doctorId, DateTime appointmentDateTime)
        {

            WorkingTime? workingTime = await _workingTimeRepository.GetMostRecentAsync(true);
            Doctor? doctor = await _doctorRepository.GetAsync(d => d.Id == doctorId, include: i => i.Include(d => d.Clinic).Include(d => d.DoctorNoWorkHours).ThenInclude(n => n.NoWorkHour));


            // Dakikanın 20 dakikalık dilimlere bölünüp bölünmediğini kontrol eder
            bool isValid = (appointmentDateTime.Minute % doctor.Clinic.AppointmentDuration) == 0;
            if (!isValid)
            {
                throw new BusinessException("Randevu zamanı geçersiz!");
            }

            TimeSpan appointmentTime = appointmentDateTime.TimeOfDay;

            // Randevu zamanının çalışma saatleri içerisinde olup olmadığını kontrol et
            if (appointmentTime < workingTime.StartTime || appointmentTime > workingTime.EndTime)
            {
                throw new BusinessException("Randevu zamanı mesai saatleri dışında.");
            }

            // Randevu zamanının mola saatleri içerisinde olup olmadığını kontrol et
            if (appointmentTime >= workingTime.StartBreakTime && appointmentTime <= workingTime.EndBreakTime)
            {
                throw new BusinessException("Randevu zamanı mola saatleri içerisinde.");
            }

            // Randevu zamanının doktorun müsait olmadığı zamanlar içerisinde olup olmadığını kontrol et
            foreach (var doctorNoWorkHour in doctor.DoctorNoWorkHours)
            {
                if (appointmentDateTime >= doctorNoWorkHour.NoWorkHour.StartDate && appointmentDateTime <= doctorNoWorkHour.NoWorkHour.EndDate)
                {
                    throw new BusinessException($"Randevu zamanı doktorun '{ doctorNoWorkHour.NoWorkHour.Title }' nedeniyle müsait olmadığı saatler içerisinde.");
                }
            }

        }
    }
}
