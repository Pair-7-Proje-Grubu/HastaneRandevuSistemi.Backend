using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using MediatR;

namespace Application.Features.Doctors.Commands.UpdateDoctorOfficeLocation
{
    public class UpdateDoctorOfficeLocationCommand : IRequest<UpdateDoctorOfficeLocationResponse>, ISecuredRequest
    {
        public int DoctorId { get; set; }
        public int BlockId { get; set; }
        public int FloorId { get; set; }
        public int RoomId { get; set; }

        public string[] RequiredRoles => ["Admin"];

        public class UpdateDoctorOfficeLocationCommandHandler : IRequestHandler<UpdateDoctorOfficeLocationCommand, UpdateDoctorOfficeLocationResponse>
        {
            private readonly IDoctorRepository _doctorRepository;
            private readonly IOfficeLocationRepository _officeLocationRepository;
            private readonly IMapper _mapper;

            public UpdateDoctorOfficeLocationCommandHandler(IDoctorRepository doctorRepository, IOfficeLocationRepository officeLocationRepository, IMapper mapper)
            {
                _doctorRepository = doctorRepository;
                _officeLocationRepository = officeLocationRepository;
                _mapper = mapper;
            }

            public async Task<UpdateDoctorOfficeLocationResponse> Handle(UpdateDoctorOfficeLocationCommand request, CancellationToken cancellationToken)
            {
                // Doktorun var olup olmadığını kontrol et
                var doctor = await _doctorRepository.GetAsync(d => d.Id == request.DoctorId);
                if (doctor == null)
                {
                    throw new BusinessException("Belirtilen ID'ye sahip doktor bulunamadı.");
                }

                // Girilen Block, Floor, Room ID'lerinin geçerli olup olmadığını kontrol et
                var officeLocation = await _officeLocationRepository.GetAsync(o =>
                    o.BlockId == request.BlockId &&
                    o.FloorId == request.FloorId &&
                    o.RoomId == request.RoomId);

                if (officeLocation == null)
                {
                    throw new BusinessException("Girilen Block, Floor ve Room ID'lerine ait ofis konumu bulunamadı.");
                }

                // Girilen ofis konumunun başka bir doktora atanıp atanmadığını kontrol et
                var existingDoctorWithSameLocation = await _doctorRepository.GetAsync(d => d.OfficeLocationId == officeLocation.Id);
                if (existingDoctorWithSameLocation != null && existingDoctorWithSameLocation.Id != request.DoctorId)
                {
                    throw new BusinessException("Girilen ofis konumu başka bir doktora atanmış durumda.");
                }

                // Ofis konumunu doktora ata
                doctor.OfficeLocationId = officeLocation.Id;
                await _doctorRepository.UpdateAsync(doctor);

                var response = _mapper.Map<UpdateDoctorOfficeLocationResponse>(doctor);
                return response;
            }
        }
    }
}
