using AutoMapper;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InterviewManagementSystem.MVC.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CandidatesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var allCandidates = _unitOfWork.GetRepository<Candidate>()
                .GetAll(includeProperties: "Recruiter,Status");

            var indexCandidates = new List<CandidateViewModel>();

            foreach (var candidate in allCandidates)
            {
                var indexCandidateMapped = _mapper.Map<CandidateViewModel>(candidate);
                indexCandidates.Add(indexCandidateMapped);
            }

            return View(indexCandidates);
        }

        public IActionResult Create()
        {
            ViewData["RecruiterId"] = new SelectList(_unitOfWork.GetRepository<User>().GetAll(), "Id", "FullName");
            ViewData["StatusId"] = new SelectList(_unitOfWork.GetRepository<CandidateStatus>().GetAll(), "Id", "StatusName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FullName,DateOfBirth,PhoneNumber,Email,Address,Gender,StatusId,YearOfExperience,RecruiterId,Note")] CandidateViewModel candidateViewModel)
        {
            if (ModelState.IsValid)
            {
                Candidate candidate = _mapper.Map<Candidate>(candidateViewModel);
                _unitOfWork.GetRepository<Candidate>().Insert(candidate);
                _unitOfWork.GetRepository<Candidate>().Save();
                TempData["success"] = "Create new candidate successfully!";

                return RedirectToAction(nameof(Index));
            }

            ViewData["RecruiterId"] = new SelectList(_unitOfWork.GetRepository<User>().GetAll(), "Id", "FullName", candidateViewModel.RecruiterId);
            ViewData["StatusId"] = new SelectList(_unitOfWork.GetRepository<CandidateStatus>().GetAll(), "Id", "StatusName", candidateViewModel.StatusId);

            return View(candidateViewModel);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = _unitOfWork.GetRepository<Candidate>().GetById(id);

            if (candidate == null)
            {
                return NotFound();
            }

            var candidateViewModel = _mapper.Map<CandidateViewModel>(candidate);

            ViewData["RecruiterId"] = new SelectList(_unitOfWork.GetRepository<User>().GetAll(), "Id", "FullName", candidateViewModel.RecruiterId);
            ViewData["StatusId"] = new SelectList(_unitOfWork.GetRepository<CandidateStatus>().GetAll(), "Id", "StatusName", candidateViewModel.StatusId);

            return View(candidateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,FullName,DateOfBirth,PhoneNumber,Email,Address,Gender,StatusId,YearOfExperience,RecruiterId,Note")] CandidateViewModel candidateViewModel)
        {
            if (id != candidateViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Candidate candidate = _mapper.Map<Candidate>(candidateViewModel);
                    _unitOfWork.GetRepository<Candidate>().Update(candidate);
                    _unitOfWork.GetRepository<Candidate>().Save();
                    TempData["success"] = "Edit candidate successfully!";

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateExists(candidateViewModel.Id))
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

            ViewData["RecruiterId"] = new SelectList(_unitOfWork.GetRepository<User>().GetAll(), "Id", "FullName", candidateViewModel.RecruiterId);
            ViewData["StatusId"] = new SelectList(_unitOfWork.GetRepository<CandidateStatus>().GetAll(), "Id", "StatusName", candidateViewModel.StatusId);

            return View(candidateViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var candidate = _unitOfWork.GetRepository<Candidate>().FirstOrDefaultInclude(c => c.Id == id, "Offer", "Schedule");

            if (candidate != null)
            {
                _unitOfWork.GetRepository<Candidate>().Delete(candidate);
                _unitOfWork.GetRepository<Offer>().Delete(candidate.Offer?.Id);
                _unitOfWork.GetRepository<Schedule>().Delete(candidate.Schedule?.Id);
                _unitOfWork.SaveChanges();
                TempData["success"] = "Delete candidate successfully!";

            }
            else
            {
                TempData["error"] = "Delete candidate failed!";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CandidateExists(int id)
        {
            return _unitOfWork.GetRepository<Candidate>().GetById(id) != null;
        }
    }
}
