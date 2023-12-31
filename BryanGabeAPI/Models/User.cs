﻿using System;
using System.Text.Json.Serialization;

namespace BryanGabeAPI.Models
{
	public class User
	{
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte[]? HashPassword { get; set; }
        public string Email { get; set; } = null!;
        public DateTime Dob { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? LastLogin { get; set; }
        public int RoleId { get; set; }

        [JsonIgnore]
        public bool? Deleted { get; set; }


    }
}

