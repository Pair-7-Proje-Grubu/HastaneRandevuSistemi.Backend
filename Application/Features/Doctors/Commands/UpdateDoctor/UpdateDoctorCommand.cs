using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorCommand :  IRequest<UpdateDoctorResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
        public int TitleId { get; set; }
        public int ClinicId { get; set; }
        public int OfficeLocationId { get; set; }


        public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, UpdateDoctorResponse>
        {

            private readonly IDoctorRepository _doctorRepository;
            private readonly IMapper _mapper;

            public UpdateDoctorCommandHandler(IDoctorRepository doctorRepository, IMapper mapper)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
            }

            public async Task<UpdateDoctorResponse> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
            {
                Doctor doctor = _mapper.Map<Doctor>(request);

                await _doctorRepository.UpdateAsync(doctor);

                UpdateDoctorResponse response = new UpdateDoctorResponse();
                return response;
            }
        }


    }
}
