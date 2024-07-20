using Application.Features.Users.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Extensions;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Commands.Cancel.ByDoctor
{
    public class CancelAppointmentByDoctorCommand : IRequest<CancelAppointmentByDoctorResponse>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] RequiredRoles => ["Doctor"];

        public class CancelAppointmentByDoctorCommandHandler : IRequestHandler<CancelAppointmentByDoctorCommand, CancelAppointmentByDoctorResponse>
        {
            private readonly IMapper _mapper;
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly UserBusinessRules _userBusinessRules;

            public CancelAppointmentByDoctorCommandHandler(IMapper mapper, IAppointmentRepository appointmentRepository, IHttpContextAccessor httpContextAccessor, UserBusinessRules userBusinessRules)
            {
                _mapper = mapper;
                _appointmentRepository = appointmentRepository;
                _httpContextAccessor = httpContextAccessor;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<CancelAppointmentByDoctorResponse> Handle(CancelAppointmentByDoctorCommand request, CancellationToken cancellationToken)
            {
                int userId = _httpContextAccessor.HttpContext.User.GetUserId();

                await _userBusinessRules.UserIdShouldExistWhenSelected(userId);

                Appointment? appointment = await _appointmentRepository.GetAsync(a => a.Id == request.Id && a.DoctorId == userId, include: a => a.Include(p => p.Patient));

                if (appointment == null)
                {
                    throw new BusinessException("Randevu bulunamadı");
                }

                if (appointment.Status == AppointmentStatus.CancelByDoctor || appointment.Status == AppointmentStatus.CancelByPatient)
                {
                    throw new BusinessException("İptal edilen randevu tekrar iptal edilemez");
                }

                appointment.Status = AppointmentStatus.CancelByDoctor;

                _mapper.Map(request, appointment);

                await _appointmentRepository.UpdateAsync(appointment);

                CancelAppointmentByDoctorResponse response = _mapper.Map<CancelAppointmentByDoctorResponse>(appointment);

                return response;
            }
        }
    }
}
