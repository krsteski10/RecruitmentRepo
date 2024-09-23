using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RecruitmentAPI.Models
{
    public class InterviewFeedback
    {
        [JsonPropertyName("interviewFeedbackId")]
        public int Id { get; set; }

        public int? CandidateId { get; set; }

        public string Feedback { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; } // Optional - rating from 1-5

        [JsonIgnore] // Prevents serialization of the Candidate back-reference
        public Candidate? Candidate { get; set; } // Foreign key relationship
    }
}