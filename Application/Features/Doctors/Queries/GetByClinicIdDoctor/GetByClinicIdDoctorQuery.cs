using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Features.Doctors.Queries.GetByClinicIdDoctor
{
    public class GetByClinicIdDoctorQuery : IRequest<List<GetByClinicIdDoctorResponse>>
    {
        public int ClinicId { get; set; } 

        public class GetByClinicIdDoctorQueryHandler : IRequestHandler<GetByClinicIdDoctorQuery, List<GetByClinicIdDoctorResponse>>
        {

            private readonly IDoctorRepository _doctorRepository;
            private IMapper _mapper;

            public GetByClinicIdDoctorQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
            }


            public async Task<List<GetByClinicIdDoctorResponse>> Handle(GetByClinicIdDoctorQuery request, CancellationToken cancellationToken)
            {
                
                List<Doctor> doctor = await _doctorRepository.GetListAsync(x=> x.ClinicId == request.ClinicId,
                        include: d => d.Include(d => d.User).Include(d => d.Title));

                List<GetByClinicIdDoctorResponse> response = _mapper.Map<List<GetByClinicIdDoctorResponse>>(doctor);
                return response;
            }
        }
    }
}


