#nullable enable

namespace ResumeBuilderAPI.Models
{
    public partial class Skill
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}