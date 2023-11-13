﻿#nullable enable

namespace ResumeAPI.Models
{
    public partial class File
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Data { get; set; } = null!;
    }
}