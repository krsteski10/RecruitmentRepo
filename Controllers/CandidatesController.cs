using Microsoft.AspNetCore.Mvc;
using RecruitmentAPI.BusinessLayer.Interfaces;
using RecruitmentAPI.Core.Models;

namespace RecruitmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : Controller
    {
        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        // GET: api/candidates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidates([FromQuery] FilterOptions filter)
        {
            var candidates = await _candidateService.GetFilteredCandidatesAsync(filter);
            return Ok(candidates);
        }

        // GET: api/candidates/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Candidate>> GetCandidateById(int id)
        {
            var candidate = await _candidateService.GetCandidateByIdAsync(id);

            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }

        // POST: api/candidates
        [HttpPost]
        public async Task<IActionResult> PostCandidate(Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _candidateService.AddCandidateAsync(candidate);

            return CreatedAtAction(nameof(GetCandidateById), new { id = candidate.Id }, candidate);
        }

        // PUT: api/candidates/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidate(int id, Candidate candidate)
        {
            if (id != candidate.Id)
            {
                return BadRequest();
            }

            try
            {
                await _candidateService.UpdateCandidateAsync(candidate);
            }
            catch
            {
                if (!_candidateService.CandidateExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/candidates/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            var candidate = await _candidateService.GetCandidateByIdAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            await _candidateService.DeleteCandidateAsync(id);

            return NoContent();
        }
    }
}
