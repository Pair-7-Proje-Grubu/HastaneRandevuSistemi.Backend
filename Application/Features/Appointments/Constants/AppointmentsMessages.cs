namespace Application.Features.Appointments.Constants
{
    public static class AppointmentsMessages
    {
        public const string AppointmentNotFound = "Randevu bulunamadı.";
        public const string AppointmentHasAlreadyBeenBooked = "Randevu önceden alınmış.";
        public const string AppointmentHasAlreadyBeenCancelled = "Randevu önceden iptal edilmiş.";
        public const string AppointmentTimeIsInvalid = "Randevu zamanı geçersiz.";
        public const string AppointmentTimeIsOutsideWorkingHours = "Randevu zamanı mesai saatleri dışında.";
        public const string AppointmentTimeIsDuringBreakHours = "Randevu zamanı mola saatleri içerisinde.";
        public const string UserAndPatientIsNotEqual = "Kullanıcı ile hasta eşleşmiyor.";
        public static string AppointmentTimeIsDuringNoWorkHours(string title) => $"Randevu zamanı doktorun '{title}' nedeniyle müsait olmadığı saatler içerisinde.";
    }

}
