using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BryanGabeDAL.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string HashPassword { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime Dob { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastLogin { get; set; }
        public int RoleId { get; set; }
        public bool Deleted { get; set; }

        [JsonIgnore]
        public virtual Role Role { get; set; } = null!;
    }
}
