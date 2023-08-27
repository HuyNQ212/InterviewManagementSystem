using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterviewManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidatesController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        // GET: api/Candidates
        [HttpGet]
        [EnableCors]
        public ActionResult<IEnumerable<Candidate>> GetCandidates()
        {

            if (_candidateRepository.GetAll().Count() == 0)
            {
                return NotFound();
            }
            return Ok(_candidateRepository.GetAll().ToList());


        }

        // GET: api/Candidates/5
        [HttpGet("{id}")]
        public ActionResult<Candidate> GetCandidate(int id)
        {
            if (_candidateRepository.GetAll().Count() == 0)
            {
                return NotFound();
            }

            var candidate = _candidateRepository.GetById(id);

            if (candidate == null)
            {
                return NotFound();
            }

            return candidate;
        }

        // PUT: api/Candidates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutCandidate(int id, Candidate candidate)
        {
            if (id != candidate.Id)
            {
                return BadRequest();
            }

            //_context.Entry(candidate).State = EntityState.Modified;

            if (_candidateRepository.GetById(id) != null)
            {
                _candidateRepository.Update(candidate);
                _candidateRepository.Save();

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Candidates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Candidate> PostCandidate(Candidate candidate)
        {
            if (_candidateRepository.GetAll().Count() == 0)
            {
                return Problem("Entity set 'InterviewManagementContext.Candidates'  is null.");
            }

            _candidateRepository.Insert(candidate);
            _candidateRepository.Save();

            return CreatedAtAction("GetCandidate", new { id = candidate.Id }, candidate);
        }

        // DELETE: api/Candidates/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCandidate(int id)
        {
            if (_candidateRepository.GetAll().Count() == 0)
            {
                return NotFound();
            }

            var candidate = _candidateRepository.GetById(id);

            if (candidate == null)
            {
                return NotFound();
            }

            _candidateRepository.Delete(candidate);
            _candidateRepository.Save();

            return NoContent();
        }

        private bool CandidateExists(int id)
        {
            return (_candidateRepository.GetById(id) != null);
        }
    }
}
