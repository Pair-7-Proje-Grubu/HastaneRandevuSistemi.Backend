using MediatR;
using AutoMapper;
using Application.Repositories;
using Domain.Entities;
using SendGrid.Helpers.Errors.Model;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Extensions;
using Core.Application.Pipelines.Authorization;

namespace Application.Features.Users.Queries.GetProfile
{
    public class GetProfileQuery : IRequest<GetProfileResponse>, ISecuredRequest
    {
        public string[] RequiredRoles => ["Patient"];
        public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, GetProfileResponse>
        {
            private readonly IPatientRepository _patientRepository;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public GetProfileQueryHandler(IPatientRepository patientRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            {
                _patientRepository = patientRepository;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<GetProfileResponse> Handle(GetProfileQuery request, CancellationToken cancellationToken)
            {
                int userId = _httpContextAccessor.HttpContext.User.GetUserId();
                Patient? patient = await _patientRepository.GetAsync(p => p.Id == userId);
                if (patient == null)
                {
                    throw new NotFoundException("Böyle bir kullanıcı bulunamadı.");
                }
                GetProfileResponse response = _mapper.Map<GetProfileResponse>(patient);
                return response;
            }
        }
    }
}