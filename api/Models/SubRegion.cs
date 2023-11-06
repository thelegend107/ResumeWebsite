using System.Collections.Generic;

namespace Api.Models
{
    public partial class SubRegion
    {
        public SubRegion()
        {
            Countries = new HashSet<Country>();
        }

        public int Id { get; set; }
        public int? RegionId { get; set; }
        public string Name { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
    }
}