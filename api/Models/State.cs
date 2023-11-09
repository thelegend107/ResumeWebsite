#nullable enable

namespace ResumeBuilderAPI.Models
{
    public partial class State
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string StateCode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}