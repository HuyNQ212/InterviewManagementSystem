using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InterviewManagementSystem.MVC.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly InterviewManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public CandidatesController(InterviewManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Candidates
        public IActionResult Index()
        {
            var allCandidates = _unitOfWork.GetRepository<Candidate>().GetAll(includeProperties: "Recruiter,Status");
            return View(allCandidates);
        }

        // GET: Candidates/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Candidates == null)
            {
                return NotFound();
            }

            var candidate = _unitOfWork.GetRepository<Candidate>()
                .GetAll(filter: x => x.Id == id, includeProperties: "Recruiter,Status");

            if (candidate.Count() == 0)
            {
                return NotFound();
            }

            return View(candidate.ToList()[0]);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            ViewData["RecruiterId"] = new SelectList(_unitOfWork.GetRepository<User>().GetAll(), "Id", "FullName");
            ViewData["StatusId"] = new SelectList(_unitOfWork.GetRepository<CandidateStatus>().GetAll(), "Id", "StatusName");
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FullName,DateOfBirth,PhoneNumber,Email,Address,Gender,Cvattachment,StatusId,YearOfExperience,RecruiterId,Note,CreatedAt,UpdatedAt,IsActive")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GetRepository<Candidate>().Insert(candidate);
                _unitOfWork.GetRepository<Candidate>().Save();
                return RedirectToAction(nameof(Index));
            }

            ViewData["RecruiterId"] = new SelectList(_unitOfWork.GetRepository<User>().GetAll(), "Id", "FullName", candidate.RecruiterId);
            ViewData["StatusId"] = new SelectList(_unitOfWork.GetRepository<CandidateStatus>().GetAll(), "Id", "StatusName", candidate.StatusId);

            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public  IActionResult Edit(int? id)
        {
            if (id == null || _context.Candidates == null)
            {
                return NotFound();
            }

            var candidate = _unitOfWork.GetRepository<Candidate>().GetById(id);

            if (candidate == null)
            {
                return NotFound();
            }

            ViewData["RecruiterId"] = new SelectList(_unitOfWork.GetRepository<User>().GetAll(), "Id", "FullName", candidate.RecruiterId);
            ViewData["StatusId"] = new SelectList(_unitOfWork.GetRepository<CandidateStatus>().GetAll(), "Id", "StatusName", candidate.StatusId);
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,FullName,DateOfBirth,PhoneNumber,Email,Address,Gender,Cvattachment,StatusId,YearOfExperience,RecruiterId,Note")] Candidate candidate)
        {
            if (id != candidate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.GetRepository<Candidate>().Update(candidate);
                    _unitOfWork.GetRepository<Candidate>().Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateExists(candidate.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["RecruiterId"] = new SelectList(_unitOfWork.GetRepository<User>().GetAll(), "Id", "FullName", candidate.RecruiterId);
            ViewData["StatusId"] = new SelectList(_unitOfWork.GetRepository<CandidateStatus>().GetAll(), "Id", "StatusName", candidate.StatusId);
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Candidates == null)
            {
                return NotFound();
            }

            var candidate = _unitOfWork.GetRepository<Candidate>()
                .GetAll(filter: x => x.Id == id, includeProperties: "Recruiter,Status");

            if (candidate.Count() == 0)
            {
                return NotFound();
            }

            return View(candidate.ToList()[0]);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Candidates == null)
            {
                return Problem("Entity set 'InterviewManagementContext.Candidates'  is null.");
            }

            var candidate = _unitOfWork.GetRepository<Candidate>().GetById(id);

            if (candidate != null)
            {
                _unitOfWork.GetRepository<Candidate>().Delete(candidate);
                _unitOfWork.GetRepository<Candidate>().Save();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CandidateExists(int id)
        {
            return _unitOfWork.GetRepository<Candidate>().GetById(id) != null;
        }
    }
}
