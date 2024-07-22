using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Doctors.Queries.GetByIdDoctor
{
    public class GetByIdDoctorQuery : IRequest<GetByIdDoctorResponse>
    {
        public int Id { get; set; } 

        public class GetByIdDoctorQueryHandler : IRequestHandler<GetByIdDoctorQuery, GetByIdDoctorResponse>
        {

            private readonly IDoctorRepository _doctorRepository;
            private IMapper _mapper;

            public GetByIdDoctorQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
            }


            public async Task<GetByIdDoctorResponse> Handle(GetByIdDoctorQuery request, CancellationToken cancellationToken)
            {
                
                Doctor? doctor = await _doctorRepository.GetAsync(x=> x.Id == request.Id);
                GetByIdDoctorResponse response = _mapper.Map<GetByIdDoctorResponse>(doctor);

                return response;
            }
        }
    }
}


