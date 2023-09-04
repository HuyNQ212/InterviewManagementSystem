using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InterviewManagementSystem.MVC.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IScheduleRepository _scheduleRepository;

        public SchedulesController(IUnitOfWork unitOfWork, IScheduleRepository scheduleRepository)
        {
            _unitOfWork = unitOfWork;
            _scheduleRepository = scheduleRepository;
        }

        // GET: Schedules
        public IActionResult Index()
        {
            var schedules = _scheduleRepository.GetAll(includeProperties: "Candidate");

            return View(schedules);
        }

        // GET: Schedules/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = _scheduleRepository.GetById(id);

            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        public IActionResult Create()
        {
            var candidateDontHaveInterviewSchedule = _unitOfWork.GetRepository<Candidate>()
                .GetAll(filter: c => c.Schedule == null);

            ViewBag.CandidateId = new SelectList(candidateDontHaveInterviewSchedule, "Id", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,InterviewTimeStart,InterviewTimeEnd,Location,MeetingId,Note,Result,CandidateId")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _scheduleRepository.Insert(schedule);
                _scheduleRepository.Save();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CandidateId = new SelectList(_unitOfWork.GetRepository<Candidate>().GetAll(), "Id", "FullName");

            return View(schedule);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = _scheduleRepository.GetById(id);

            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,InterviewTimeStart,InterviewTimeEnd,Location,MeetingId,Note,Result")] Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _scheduleRepository.Update(schedule);
                    _scheduleRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_scheduleRepository.GetById(id) == null)
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

            return View(schedule);
        }

  
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = _scheduleRepository.GetById(id);

            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var schedule = _scheduleRepository.GetById(id);
            if (schedule != null)
            {
                _scheduleRepository.Delete(schedule);
            }

            _scheduleRepository.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}
