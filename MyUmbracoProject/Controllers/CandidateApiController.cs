using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Services;
using System.Text.Json;
using MyUmbracoProject;

[Route("umbraco/api/[controller]")]
public class CandidateApiController : ControllerBase
{
    private readonly IContentService _contentService;

    public CandidateApiController(IContentService contentService)
    {
        _contentService = contentService;
    }

    [HttpGet("getcandidates")]
    public IActionResult GetCandidates()
    {
        // Fetch content of type 'candidate'
        var candidates = _contentService.GetPagedChildren(-1, 0, 100, out long totalRecords)
            .Where(x => x.ContentType.Alias == "candidate")
            .Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                Skills = JsonSerializer.Deserialize<List<string>>(x.GetValue<string>("skills") ?? "[]"),
                Experience = x.GetValue<int>("experience"),
                InterviewFeedback = x.GetValue<string>("interviewFeedback"),
                IsHired = x.GetValue<bool>("decisionStatus")
            });

        return new JsonResult(candidates, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        });
    }

    [HttpPost("createcandidate")]
    public IActionResult CreateCandidate([FromBody] CandidateModel candidateModel)
    {
        // Create a new candidate node in Umbraco
        var candidate = _contentService.Create(candidateModel.Name, -1, "candidate");
        candidate.SetValue("candidateName", candidateModel.Name);
        candidate.SetValue("skills", JsonSerializer.Serialize(candidateModel.Skills));
        candidate.SetValue("experience", candidateModel.Experience);
        candidate.SetValue("interviewFeedback", candidateModel.InterviewFeedback);
        candidate.SetValue("decisionStatus", candidateModel.IsHired);

        // Save the candidate
        _contentService.Save(candidate);

        // Publish the candidate
        _contentService.Publish(candidate, []);

        return CreatedAtAction(nameof(GetCandidates), new { id = candidate.Id }, candidate);
    }

    [HttpPut("updatecandidate/{id}")]
    public IActionResult UpdateCandidate(int id, [FromBody] CandidateModel candidateModel)
    {
        var candidate = _contentService.GetById(id);
        if (candidate == null)
        {
            return NotFound();
        }

        candidate.SetValue("candidateName", candidateModel.Name);
        candidate.SetValue("skills", JsonSerializer.Serialize(candidateModel.Skills));
        candidate.SetValue("experience", candidateModel.Experience);
        candidate.SetValue("interviewFeedback", candidateModel.InterviewFeedback);
        candidate.SetValue("decisionStatus", candidateModel.IsHired);

        // Save the candidate
        _contentService.Save(candidate);

        // Publish the candidate
        _contentService.Publish(candidate, []);

        return NoContent();
    }

    [HttpDelete("deletecandidate/{id}")]
    public IActionResult DeleteCandidate(int id)
    {
        var candidate = _contentService.GetById(id);
        if (candidate == null)
        {
            return NotFound();
        }

        _contentService.Delete(candidate);
        return NoContent();
    }
}
