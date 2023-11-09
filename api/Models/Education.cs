#nullable enable
using System;

namespace ResumeBuilderAPI.Models
{
    public partial class Education
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? AddressId { get; set; }
        public string School { get; set; } = null!;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Grade { get; set; }
    }
}