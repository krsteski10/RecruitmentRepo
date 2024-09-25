using Microsoft.AspNetCore.Mvc;
using RecruitmentAPI.BusinessLayer.Interfaces;

namespace RecruitmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet("total")]
        public async Task<IActionResult> GetTotalCandidatesCount()
        {
            var totalCandidates = await _statisticsService.GetTotalCandidatesCountAsync();
            return Ok(new { totalCandidates });
        }

        [HttpGet("decisions")]
        public async Task<IActionResult> GetJobOffersVsRejections()
        {
            var (hiredCount, rejectedCount) = await _statisticsService.GetJobOffersVsRejectionsAsync();
            return Ok(new { hiredCount, rejectedCount });
        }

        [HttpGet("averageexperience")]
        public async Task<IActionResult> GetAverageExperience()
        {
            var averageExperience = await _statisticsService.GetAverageExperienceAsync();
            return Ok(new { averageExperience });
        }

        [HttpGet("topskills")]
        public async Task<IActionResult> GetTopSkills()
        {
            var topSkills = await _statisticsService.GetTopSkillsAsync();
            return Ok(new { topSkills });
        }
    }
}
