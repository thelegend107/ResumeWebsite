﻿using MapDataReader;
using System;
using System.Collections.Generic;

namespace ResumeAPI.Entities
{
    [GenerateDataReaderMapper]
    public partial class WorkExperience
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? AddressId { get; set; }
        public string Employer { get; set; } = null!;
        public string Title { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? PayRate { get; set; }

        public virtual Address? Address { get; set; }
        public virtual IEnumerable<WorkExperienceItem> WorkExperienceItems { get; set;} = new List<WorkExperienceItem>();
    }
}