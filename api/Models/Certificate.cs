#nullable enable
using System;

namespace ResumeBuilderAPI.Models
{
    public partial class Certificate
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string? CertificateId { get; set; }
        public string? URL { get; set; }
        public string? IssuedBy { get; set; }
        public DateOnly? IssueDate { get; set; }
    }
}