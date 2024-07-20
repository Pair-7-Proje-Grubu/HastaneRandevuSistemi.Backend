using Application.Features.Doctors.Constants;
using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;


namespace Application.Features.Doctors.Rules
{
    public class DoctorBusinessRules : BaseBusinessRules
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorBusinessRules(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public Task DoctorShouldExistWhenSelected(Doctor? doctor)
        {
            if (doctor is null)
                throw new BusinessException(DoctorsMessages.DoctorNotFound);

            return Task.CompletedTask;
        }

        public async Task DoctorIdShouldExistWhenSelected(int id)
        {
            Doctor? result = await _doctorRepository.GetAsync(predicate: d => d.Id == id, asNoTracking: true);
            if (result is null)
                throw new BusinessException(DoctorsMessages.DoctorNotFound);
        }
    }
}
