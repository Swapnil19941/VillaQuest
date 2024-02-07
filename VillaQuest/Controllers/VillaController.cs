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
        public IActionResult Create(Villa obj) {
            if(obj.Name.Equals(obj.Description))
            {
                ModelState.AddModelError("Description", "The Name and Description of villa cannot be a similer");
            }
            if(ModelState.IsValid)
            {
                _dbContext.Villas.Add(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Villa");
            }

            return View(obj);
        }
    }
}
