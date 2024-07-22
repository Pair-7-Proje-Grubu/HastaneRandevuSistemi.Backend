using Application.Repositories;
using Application.Services.Common;
using Application.Services.PatientService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Patients.Queries
{
    public class GetListPatientQuery : PaginationParams, IRequest<PagedResponse<List<GetListPatientResponse>>>, ISecuredRequest
    {
        public string[] RequiredRoles => ["Admin"];
        public class GetListPatientQueryHandler : IRequestHandler<GetListPatientQuery, PagedResponse<List<GetListPatientResponse>>>
        {
            private readonly IMapper _mapper;
            private readonly IPatientRepository _patientRepository;

            public GetListPatientQueryHandler(IMapper mapper, IPatientRepository patientRepository)
            {
                _mapper = mapper;
                _patientRepository = patientRepository;
            }

            public async Task<PagedResponse<List<GetListPatientResponse>>> Handle(GetListPatientQuery request, CancellationToken cancellationToken)
            {
                List<Patient> patients = await _patientRepository.GetListAsync();

                IEnumerable<GetListPatientResponse> query = patients.Select(p =>
                {
                    var mappedPatient = _mapper.Map<GetListPatientResponse>(p);
                    mappedPatient.BloodType = p.BloodType.ConvertToString();
                    return mappedPatient;
                    }).ToList();

                return query.ToPagedResponse(request);
            }
        }
    }
}
