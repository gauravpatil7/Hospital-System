using System;
using System.Collections.Generic;

namespace HospitalWebApplication.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appontments = new HashSet<Appontment>();
        }

        public int Did { get; set; }
        public string Dname { get; set; } = null!;
        public string Degree { get; set; } = null!;
        public byte? Experience { get; set; }
        public int? Worksin { get; set; }
        public string? Dimage { get; set; }

        public virtual Hospital? WorksinNavigation { get; set; }
        public virtual ICollection<Appontment> Appontments { get; set; }
    }
}
