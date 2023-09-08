using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Dal.Models
{
    public partial class UserAppointments
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
