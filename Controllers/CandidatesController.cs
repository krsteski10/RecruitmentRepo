using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentAPI.Data;
using RecruitmentAPI.Models;
using System.Text.Json;

namespace RecruitmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : Controller
    {
        private readonly RecruitmentContext _context;
        public CandidatesController(RecruitmentContext context)
        {
            _context = context;
        }

        // GET: api/candidates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidates([FromQuery] FilterOptions filter)
        {
            var query = _context.Candidates.Include(c => c.Skills).Include(c => c.Feedbacks).AsQueryable();

            // Apply filtering here
            if (filter.Experience.HasValue)
            {
                query = query.Where(c => c.YearsOfExperience >= filter.Experience.Value);
            }
            if (!string.IsNullOrEmpty(filter.Skill))
            {
                query = query.Where(c => c.Skills.Any(s => s.Name == filter.Skill));
            }
            if (filter.IsHired.HasValue)
            {
                query = query.Where(c => c.IsHired == filter.IsHired.Value);
            }

            return await query.ToListAsync();
        }

        // GET: api/candidates/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Candidate>> GetCandidateById(int id)
        {
            var candidate = await _context.Candidates
                                          .Include(c => c.Skills)
                                          .Include(c => c.Feedbacks)
                                          .FirstOrDefaultAsync(c => c.Id == id);

            if (candidate == null)
            {
                return NotFound();
            }

            return candidate;
        }

        // POST: api/candidates
        [HttpPost]
        public async Task<IActionResult> PostCandidate(Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();

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

            _context.Entry(candidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(id))
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
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Helper methods
        private bool CandidateExists(int id)
        {
            return _context.Candidates.Any(c => c.Id == id);
        }
    }
}
