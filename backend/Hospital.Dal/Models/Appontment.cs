using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Hospital.Dal.Models
{
    public partial class Appontment
    {
        public int Appontmentid { get; set; }
        public int? Hospitalid { get; set; }
        public string? Userid { get; set; }
        public int? Doctorid { get; set; }
        public DateTime? Appointmenttime { get; set; }

        [JsonIgnore]
        public virtual Doctor? Doctor { get; set; }
        [JsonIgnore]
        public virtual Hospitall? Hospital { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
    }
}
