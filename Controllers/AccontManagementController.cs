using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using OnlineLecture.Models.Domain;

namespace OnlineLecture.Controllers
{
    public class AccontManagementController : Controller
    {
        public readonly DatabaseContext _db;
        public AccontManagementController(DatabaseContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var userList = _db.ApplicationUsers.ToList();
            return View(userList);
        }

        public async Task<IActionResult> Update(string id)
        {
            var userFromDB = _db.ApplicationUsers.FirstOrDefault(x => x.Id == id);
            return View(userFromDB);
        }

        [HttpPost]
        public IActionResult Update(ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationUsers.Update(applicationUser);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(applicationUser);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var userFromDB = _db.ApplicationUsers.FirstOrDefault(x => x.Id == id);
            return View(userFromDB);
        }

        [HttpPost]
        public IActionResult DeletePOST(string id)
        {
            var userFromDB = _db.ApplicationUsers.FirstOrDefault(x => x.Id == id);

            _db.ApplicationUsers.Remove(userFromDB);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
