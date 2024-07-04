﻿using Application.Features.Doctors.Commands.CreateDoctor;
using Application.Features.Doctors.Queries.GetByIdDoctor;
using Application.Features.Floors.Queries.GetById;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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


