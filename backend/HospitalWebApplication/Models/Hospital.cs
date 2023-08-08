using System;
using System.Collections.Generic;

namespace HospitalWebApplication.Models
{
    public partial class Hospital
    {
        public Hospital()
        {
            Appontments = new HashSet<Appontment>();
            Doctors = new HashSet<Doctor>();
        }

        public int Hospitalid { get; set; }
        public string Hospitalname { get; set; } = null!;
        public string Hospitaladdress { get; set; } = null!;
        public long Contact { get; set; }
        public string? Hospitalimage { get; set; }

        public virtual ICollection<Appontment> Appontments { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
