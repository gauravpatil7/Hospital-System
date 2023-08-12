using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Hospital.Dal.Models
{
    public partial class Hospitall
    {
        public Hospitall()
        {
            Appontments = new HashSet<Appontment>();
            Doctors = new HashSet<Doctor>();
        }

        public int Hospitalid { get; set; }
        public string Hospitalname { get; set; } = null!;
        public string Hospitaladdress { get; set; } = null!;
        public long Contact { get; set; }
        public string? Hospitalimage { get; set; }
        [JsonIgnore]
        public virtual ICollection<Appontment> Appontments { get; set; }
        [JsonIgnore]
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
