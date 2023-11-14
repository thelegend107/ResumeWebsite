using MapDataReader;

namespace ResumeAPI.Entities
{
    [GenerateDataReaderMapper]
    public partial class EducationItem
    {
        public int Id { get; set; }
        public int EducationId { get; set; }
        public string Name { get; set; } = null!;
    }
}