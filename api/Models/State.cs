using MapDataReader;

namespace api.Models
{
    [GenerateDataReaderMapper]
    public partial class State
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string StateCode { get; set; }
        public string Name { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
