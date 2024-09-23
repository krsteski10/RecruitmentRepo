using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentAPI.Data;
using System.Text.Json;

namespace RecruitmentAPI.Controllers
{
    public class StatisticsController : ControllerBase
    {
        private readonly RecruitmentContext _context;
        public StatisticsController(RecruitmentContext context)
        {
            _context = context;
        }

        //This endpoint will return the total number of candidates in the system.
        [HttpGet("statistics/total")]
        public IActionResult GetTotalCandidatesCount()
        {
            var totalCandidates = _context.Candidates.Count();
            return Ok(new { totalCandidates });
        }

        //This will return how many candidates were hired (IsHired = true) vs. rejected.
        [HttpGet("statistics/decisions")]
        public IActionResult GetJobOffersVsRejections()
        {
            var hiredCount = _context.Candidates.Count(c => c.IsHired == true);
            var rejectedCount = _context.Candidates.Count(c => c.IsHired == false);

            return Ok(new { hiredCount, rejectedCount });
        }

        //This endpoint will calculate and return the average experience.
        [HttpGet("statistics/averageexperience")]
        public IActionResult GetAverageExperience()
        {
            var totalExperience = _context.Candidates.Sum(c => c.YearsOfExperience);
            var candidateCount = _context.Candidates.Count();

            var averageExperience = candidateCount > 0 ? totalExperience / candidateCount : 0;
            return Ok(new { averageExperience });
        }

        [HttpGet("statistics/topskills")]
        public IActionResult GetTopSkills()
        {
            var candidates = _context.Candidates
                                     .Include(c => c.Skills)
                                     .ToList();

            var skills = candidates.SelectMany(c => c.Skills.Select(s => s.Name));

            var topSkills = skills.GroupBy(s => s)
                                  .Select(g => new { Skill = g.Key, Count = g.Count() })
                                  .OrderByDescending(s => s.Count)
                                  .ToList();


            return Ok(new { topSkills });
        }
    }
}
