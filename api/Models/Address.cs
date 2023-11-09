#nullable enable

namespace ResumeBuilderAPI.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
    }
}