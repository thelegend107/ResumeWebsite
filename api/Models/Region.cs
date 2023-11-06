#nullable disable
using System.Collections.Generic;

namespace Api.Models
{
    public partial class Region
    {
        public Region()
        {
            Countries = new HashSet<Country>();
            SubRegions = new HashSet<SubRegion>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<SubRegion> SubRegions { get; set; }
    }
}