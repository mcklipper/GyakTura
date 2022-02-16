using GyakTura.Data;
using GyakTura.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GyakTura.Controllers
{
    [Authorize]
    public class TourController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public TourController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        
        public IActionResult Index()
        {
            var tours = context
                .Tours
                .Where(x => x.User.Id == userManager.GetUserId(HttpContext.User))
                .OrderByDescending(x => x.Date)
                .ToList();

            return View(tours);
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var tour = context.Tours
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (tour == null)
                return NotFound();

            return View(tour);
        }

        [HttpPost]
        public IActionResult Remove(Tour tour)
        {
            context.Tours.Remove(tour);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Save(int? id = null)
        {
            if (id == null)
                return View(new Tour());

            var tour = context.Tours
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (tour == null)
                return NotFound();

            return View(tour);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Tour tour)
        {
            if (tour.Id == 0)
            {
                tour.User = await userManager.GetUserAsync(HttpContext.User);
                context.Tours.Add(tour);
                await context.SaveChangesAsync(true);
            }
            else
            {
                var tourInDb = context.Tours
                    .Where(x => x.Id == tour.Id)
                    .FirstOrDefault();

                if (tourInDb == null)
                    return BadRequest();

                tourInDb.Date = tour.Date;
                tourInDb.Destination = tour.Destination;
                tourInDb.Comment = tour.Comment;
                tourInDb.Km = tour.Km;
                await context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
