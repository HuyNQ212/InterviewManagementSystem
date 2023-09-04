using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InterviewManagementSystem.MVC.Controllers
{
    public class OffersController : Controller
    {
        private readonly IOfferRepository offerRepository;

        public OffersController(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }
        public IActionResult Index()
        {
            var offers = this.offerRepository.GetAll(
                includeProperties: "Candidate,ApprovedByManager,Department,Position");
            return View(offers);
        }

        public IActionResult Details(int id)
        {
            var offer = offerRepository
                .GetAll(
                filter: o => o.Id == id,
                includeProperties: "ApprovedByManager,Position,Department,Candidate");


            if (offer.Count() == 0)
            {
                return NotFound();
            }

            return View(offer.ToList()[0]);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var offer = offerRepository.FirstOrDefaultInclude(
                filter: o => o.Id == id,
                "ApprovedByManager","Position","Department","Candidate");

            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }
    }
}
