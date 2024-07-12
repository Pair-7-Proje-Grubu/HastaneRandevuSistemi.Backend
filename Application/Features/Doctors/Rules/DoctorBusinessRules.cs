using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Doctors.Rules
{
    public class DoctorBusinessRules : BaseBusinessRules
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorBusinessRules(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task DoctorIdShouldExistWhenSelected(int id)
        {
            Doctor? result = await _doctorRepository.GetAsync(predicate: d => d.Id == id, asNoTracking: true);
            if (result is null)
                throw new BusinessException("Doctor bulunamadı!");
        }
    }
}
