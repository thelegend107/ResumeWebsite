using MapDataReader;

namespace api.Models
{
    [GenerateDataReaderMapper]
    public partial class SubRegion
    {
        public int Id { get; set; }
        public int? RegionId { get; set; }
        public string Name { get; set; }
    }
}
