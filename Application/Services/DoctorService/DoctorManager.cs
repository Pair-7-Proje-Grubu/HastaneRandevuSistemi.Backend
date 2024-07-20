using Application.Features.Doctors.Rules;
using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.DoctorService
{
    public class DoctorManager : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly DoctorBusinessRules _doctorBusinessRules;

        public DoctorManager(IDoctorRepository doctorRepository, DoctorBusinessRules doctorBusinessRules)
        {
            _doctorRepository = doctorRepository;
            _doctorBusinessRules = doctorBusinessRules;
        }

        public async Task<Doctor> GetDoctorWithAppointmentsAndNoWorkHoursById(int doctorId, int dayCount)
        {

            Doctor? doctor = await _doctorRepository.GetAsync(
                  d => d.Id == doctorId,
                  include: d =>
                      d.Include(d => d.Clinic)
                      .Include(d => d.Appointments.Where(a => a.DateTime > DateTime.Now && a.DateTime < DateTime.Now.AddDays(dayCount)))
                      .Include(d => d.DoctorNoWorkHours.Where(nwh => nwh.NoWorkHour.StartDate.Date >= DateTime.Now.Date && nwh.NoWorkHour.EndDate.Date <= DateTime.Now.AddDays(dayCount).Date))
                          .ThenInclude(d => d.NoWorkHour), asNoTracking: true);

            await _doctorBusinessRules.DoctorShouldExistWhenSelected(doctor);

            return doctor!;

            
        }

        public async Task<Doctor> GetDoctorWithNoWorkHoursById(int doctorId)
        {
            Doctor? doctor = await _doctorRepository.GetAsync(
              predicate: d => d.Id == doctorId,
              include: i => i.Include(d => d.Clinic)
                              .Include(d => d.DoctorNoWorkHours)
                                  .ThenInclude(n => n.NoWorkHour));

            await _doctorBusinessRules.DoctorShouldExistWhenSelected(doctor);

            return doctor!;
        }
    }
}
