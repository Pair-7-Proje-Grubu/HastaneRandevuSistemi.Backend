using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Utilities.Extensions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;



namespace Application.Features.Clinics.Queries.GetByIdClinic
{
    public class GetClinicQuery : IRequest<GetClinicResponse>, ISecuredRequest
    {
        public string[] RequiredRoles => ["Doctor"];

        public class GetByIdClinicQueryHandler : IRequestHandler<GetClinicQuery, GetClinicResponse>
        {

            private readonly IDoctorRepository _doctorRepository;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public GetByIdClinicQueryHandler(IDoctorRepository doctorRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<GetClinicResponse> Handle(GetClinicQuery request, CancellationToken cancellationToken)

            {
                int userId = _httpContextAccessor.HttpContext.User.GetUserId();

                Doctor? doctor = await _doctorRepository.GetAsync(d => d.Id == userId, include: d => d.Include(c => c.Clinic));

                GetClinicResponse response = new()
                {
                    Name = doctor.Clinic.Name,
                    PhoneNumber = doctor.Clinic.PhoneNumber,
                    AppointmentDuration = doctor.Clinic.AppointmentDuration,
                };
                return response;

            }
        }
    }


}
