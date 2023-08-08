using System;
using System.Collections.Generic;

namespace HospitalWebApplication.Models
{
    public partial class Appontment
    {
        public int Appontmentid { get; set; }
        public int? Hospitalid { get; set; }
        public string? Userid { get; set; }
        public int? Doctorid { get; set; }
        public DateTime? Appointmenttime { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Hospital? Hospital { get; set; }
        public virtual User? User { get; set; }
    }
}
