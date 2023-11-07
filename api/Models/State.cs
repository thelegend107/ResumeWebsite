using Newtonsoft.Json;

namespace ResumeBuilderAPI.Models
{
    public partial class State
    {
        public int Id { get; set; }
        [JsonIgnore]
        public int CountryId { get; set; }
        public string StateCode { get; set; }
        public string Name { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        [JsonIgnore]
        public virtual Country Country { get; set; }
    }
}