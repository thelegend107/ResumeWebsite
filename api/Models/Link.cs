﻿#nullable enable

namespace ResumeAPI.Models
{
    public partial class Link
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string URL { get; set; } = null!;
    }
}