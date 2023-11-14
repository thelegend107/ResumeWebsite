using MapDataReader;

namespace ResumeAPI.Entities
{
    [GenerateDataReaderMapper]
    public partial class Region
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}