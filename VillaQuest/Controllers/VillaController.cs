using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using VillaQuest.Domain.Entities;
using VillaQuest.Infrastrucutre.Data;

namespace VillaQuest.Controllers
{
    public class VillaController : Controller
    {
        private ApplicationDBContext _dbContext;

        public VillaController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var villas = _dbContext.Villas.ToList();
            return View(villas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa villa)
        {
            if (villa.Name.Equals(villa.Description))
            {
                ModelState.AddModelError("Description", "The Name and Description of villa cannot be a similer");
            }
            if (ModelState.IsValid)
            {
                _dbContext.Villas.Add(villa);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Villa");
            }

            return View(villa);
        }

        [HttpGet]
        public IActionResult Update(int villaId)
        {
            Villa villa = _dbContext.Villas.FirstOrDefault(u => u.Id == villaId);

            if (villa == null)
            {
                return View("Error", "Home");
            }

            return View(villa);
        }

        [HttpPost]
        public IActionResult Update(Villa villa)
        {
            if (villa == null && villa.Id > 0)
            {

                return View("Error", "Home");
            }

            _dbContext.Villas.Update(villa);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int villaId)
        {
            Villa villa = _dbContext.Villas.FirstOrDefault(v => v.Id == villaId);

            if (villa is null)
            {
                return View("Error", "Home");
            }

            return View(villa);

        }

        [HttpPost]
        public IActionResult Delete(Villa villa)
        {

            if (villa is not null && villa.Id > 0)
            {
                _dbContext.Villas.Remove(villa);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("Error", "Home");
        }
    }
}
