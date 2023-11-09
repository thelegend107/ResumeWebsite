#nullable enable

namespace ResumeBuilderAPI.Models
{
    public partial class WorkExperienceItem
    {
        public int Id { get; set; }
        public int WorkExperienceId { get; set; }
        public string Description { get; set; } = null!;
    }
}