using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Doctors.Commands.DeleteDoctor
{
    public class DeleteDoctorCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand>
        {

            private readonly IDoctorRepository _doctorRepository;

            public DeleteDoctorCommandHandler(IDoctorRepository doctorRepository, IMapper mapper)
            {
                _doctorRepository = doctorRepository;
            }


            public async Task Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
            {
                Doctor? doctor = await _doctorRepository.GetAsync(i => i.Id == request.Id);

                if (doctor is null)
                    throw new Exception("Böyle bir veri bulunamadı.");


                await _doctorRepository.DeleteAsync(doctor);

            }
        }

    }
}
