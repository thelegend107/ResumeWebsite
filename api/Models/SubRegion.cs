﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public partial class SubRegion
    {
        public SubRegion()
        {
            Countries = new HashSet<Country>();
        }

        [Key]
        public int Id { get; set; }
        public int? RegionId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [ForeignKey("RegionId")]
        [InverseProperty("SubRegions")]
        public virtual Region Region { get; set; }
        [InverseProperty("SubRegion")]
        public virtual ICollection<Country> Countries { get; set; }
    }
}