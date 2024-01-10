using Thelegend107.Data.Lib.Entities;

namespace ResumeAPI.Models
{
    public class ResumeModel
    {
        public User? User { get; set; }
        public Address? Address { get; set; }
        public IEnumerable<Education> Educations { get; set; } = new List<Education>();
        public IEnumerable<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
        public IEnumerable<Skill> Skills { get; set; } = new List<Skill>();
        public IEnumerable<Certificate> Certificates { get; set; } = new List<Certificate>();
        public IEnumerable<Link> Links { get; set; } = new List<Link>();
    }
}
