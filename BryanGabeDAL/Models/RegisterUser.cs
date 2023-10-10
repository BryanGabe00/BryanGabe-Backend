using System;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BryanGabeDAL.Models
{
    [Keyless]
	public class RegisterUser
	{
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime Dob { get; set; }
        public int RoleId { get; set; }

    }
}

