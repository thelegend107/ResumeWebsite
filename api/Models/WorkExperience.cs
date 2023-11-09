#nullable enable
using System;

namespace ResumeBuilderAPI.Models
{
    public partial class WorkExperience
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? AddressId { get; set; }
        public string Employer { get; set; } = null!;
        public string Title { get; set; } = null!;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public decimal? PayRate { get; set; }
    }
}