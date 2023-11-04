﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public partial class State
    {
        public State()
        {
            Cities = new HashSet<City>();
        }

        [Key]
        public int Id { get; set; }
        public int CountryId { get; set; }
        [Required]
        [StringLength(50)]
        public string StateCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        [ForeignKey("CountryId")]
        [InverseProperty("States")]
        public virtual Country Country { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<City> Cities { get; set; }
    }
}