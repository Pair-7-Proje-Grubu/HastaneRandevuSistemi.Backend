using Domain.Entities;

namespace Application.Services.DoctorService
{
    public interface IDoctorService
    {
        Task<Doctor> GetDoctorWithAppointmentsAndNoWorkHoursById(int doctorId, int dayCount);
        Task<Doctor> GetDoctorWithNoWorkHoursById(int doctorId);

    }
}
