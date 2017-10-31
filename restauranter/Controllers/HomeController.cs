using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using restauranter.Models;
using Microsoft.EntityFrameworkCore;

namespace restauranter.Controllers
{
    public class HomeController : Controller
    {
        private ReviewContext _context;
        public HomeController(ReviewContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(CreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                Review NewReview = new Review
                {
                    reviewer = model.reviewer,
                    restaurant = model.restaurant,
                    review = model.review,
                    stars = model.stars,
                    visited = model.visited,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                };
                _context.Add(NewReview);
                _context.SaveChanges();
                return RedirectToAction("Display");
            }
            return View("Index");
        }
        [HttpGet]
        [Route("display")]
        public IActionResult Display()
        {
            List<Review> AllReviews = _context.Reviews.ToList();
            ViewBag.reviews = AllReviews;
            return View("Display");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
