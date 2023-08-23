using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Hospital.Dal.Models
{
    public partial class User
    {
        public User()
        {
            Appontments = new HashSet<Appontment>();
        }

        public string Mailid { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? Pastproblems { get; set; }
        public long Contactumber { get; set; }
        public string Useraddress { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Appontment> Appontments { get; set; }
    }
}
