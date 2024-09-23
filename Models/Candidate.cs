using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RecruitmentAPI.Models
{
    public class Candidate
    {
        [JsonPropertyName("candidateId")]
        public int Id { get; set; }

        [JsonPropertyName("candidateName")]
        public string Name { get; set; }

        [Range(0, 50)]
        public int YearsOfExperience { get; set; }

        public List<Skill> Skills { get; set; } // List of skills

        public bool IsHired { get; set; } // true for hire, false for reject

        public List<InterviewFeedback> Feedbacks { get; set; } // List of feedbacks
    }
}