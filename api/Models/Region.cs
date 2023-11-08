using MapDataReader;

namespace api.Models
{
    [GenerateDataReaderMapper]
    public partial class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
