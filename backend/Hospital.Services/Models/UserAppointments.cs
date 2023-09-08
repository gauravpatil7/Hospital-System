using System.ComponentModel.DataAnnotations;

namespace Hospital.Services.Models
{
    public class UserAppointments
    {
        [Key]
        public int Appontmentid { get; set; }
        public DateTime AppointmentDT { get; set; }
        public string HospitalName { get; set; } = null!;
        public string HospitalAddress { get; set; } = null!;
        public long HospitalContact { get; set; }
        public string DoctorName { get; set; } = null!;
    }
}
