﻿#nullable enable

namespace ResumeBuilderAPI.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public int? AddressId { get; set; }
        public string Title { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Description { get; set; }
    }
}