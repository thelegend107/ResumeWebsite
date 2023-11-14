using MapDataReader;

namespace ResumeAPI.Entities
{
    [GenerateDataReaderMapper]
    public partial class SubRegion
    {
        public int Id { get; set; }
        public int? RegionId { get; set; }
        public string Name { get; set; } = null!;
    }
}