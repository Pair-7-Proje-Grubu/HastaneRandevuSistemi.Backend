using Application.Features.Users.Queries.GetProfile;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Extensions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Doctors.Queries.GetProfile
{
    public class GetProfileQuery : IRequest<GetProfileResponse>
    {

        public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, GetProfileResponse>
        {

            private readonly IPatientRepository _patientRepository;
            private IMapper _mapper;
            private IHttpContextAccessor _httpContextAccessor;
            public GetProfileQueryHandler(IPatientRepository patientRepository, IMapper mapper)
            {
                _patientRepository = patientRepository;
                _mapper = mapper;
            }


            public async Task<GetProfileResponse> Handle(GetProfileQuery request, CancellationToken cancellationToken)
            {
                //int userId = _httpContextAccessor.HttpContext.User.GetUserId();
                int userId = 2;
                Patient? patient = await _patientRepository.GetAsync(x => x.Id == userId);
                if (patient is null) throw new BusinessException("Bu ID'de bir hasta bulunamadı!");

                GetProfileResponse response = _mapper.Map<GetProfileResponse>(patient);
                return response;
            }
        }
    }
}


