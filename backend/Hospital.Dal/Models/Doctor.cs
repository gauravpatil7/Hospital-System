using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Hospital.Dal.Models
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
        [JsonIgnore]
        public virtual Hospitall? WorksinNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Appontment> Appontments { get; set; }
    }
}
