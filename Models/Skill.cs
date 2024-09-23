using RecruitmentAPI.Models;
using System.Text.Json.Serialization;

public class Skill
{
    [JsonPropertyName("skillId")]
    public int Id { get; set; }

    [JsonPropertyName("skillName")]
    public string Name { get; set; }

    public int? CandidateId { get; set; }

    [JsonIgnore] // Prevents serialization of the Candidate back-reference
    public Candidate? Candidate { get; set; }
}