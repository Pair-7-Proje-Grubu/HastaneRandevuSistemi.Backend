using Application.Features.Doctors.Commands.CreateDoctor;
using Application.Repositories;
using Application.Services.Common;
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

namespace Application.Features.Doctors.Queries.GetListDoctor
{
    public class GetListDoctorQuery : PaginationParams, IRequest<PagedResponse<List<GetListDoctorResponse>>>, ISecuredRequest
    {
        public string[] RequiredRoles => ["Patient", "Doctor", "Admin"];

        public class GetListDoctorQueryHandler : IRequestHandler<GetListDoctorQuery, PagedResponse<List<GetListDoctorResponse>>>
        {

            private readonly IDoctorRepository _doctorRepository;
            private readonly IMapper _mapper;

            public GetListDoctorQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
            }

            public async Task<PagedResponse<List<GetListDoctorResponse>>> Handle(GetListDoctorQuery request, CancellationToken cancellationToken)
            {

                List<Doctor> doctors = await _doctorRepository.GetListAsync(include: d => d.Include(u => u.User).Include(t => t.Title).Include(c => c.Clinic).Include(o => o.OfficeLocation));

                IEnumerable<GetListDoctorResponse> query = doctors.Select(d => new GetListDoctorResponse
                {
                    FirstName = d.User.FirstName,
                    LastName = d.User.LastName,
                    ClinicName = d.Clinic.Name,
                    Title = d.Title.TitleName,
                    Phone = d.User.Phone,
                });

                return query.ToPagedResponse(request);
            }
        }
    }
}
