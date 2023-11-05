﻿
#nullable disable
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace api.Models
{
    public partial class Country
    {
        public Country()
        {
            States = new HashSet<State>();
        }

        public int Id { get; set; }
        [JsonIgnore]
        public int? RegionId { get; set; }
        [JsonIgnore]
        public int? SubRegionId { get; set; }
        public string Name { get; set; }
        public string NativeName { get; set; }
        public string ISO3 { get; set; }
        public string ISO2 { get; set; }
        public int NumericCode { get; set; }
        public string PhoneCode { get; set; }
        public string Capital { get; set; }
        public string Currency { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public string Tld { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Emoji { get; set; }

        [JsonIgnore]
        public virtual Region Region { get; set; }
        [JsonIgnore]
        public virtual SubRegion SubRegion { get; set; }
        [JsonIgnore]
        public virtual ICollection<State> States { get; set; }
    }
}