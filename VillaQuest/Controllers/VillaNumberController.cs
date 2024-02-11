using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VillaQuest.Domain.Entities;
using VillaQuest.Infrastrucutre.Data;
using VillaQuest.ViewModels;

namespace VillaQuest.Controllers
{
    public class VillaNumberController : Controller
    {
        private ApplicationDBContext _dbContext;

        public VillaNumberController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;

        }
        public IActionResult Index()
        {
            var villaNumbers = _dbContext.VillaNumbers.ToList();
            return View(villaNumbers);
        }


        public IActionResult Create(int villaNumberId)
        {

            VillaNumberVM villaNumberVM = new VillaNumberVM()
            {
                Villas = _dbContext.Villas.ToList().Select(v => new SelectListItem
                {
                    Value = v.Id.ToString(),
                    Text = v.Name

                })
            };
            
            return View(villaNumberVM);
        }
        [HttpPost]
        public IActionResult Create(VillaNumberVM villaNumber)
        {
            //ModelState.Remove("Villa");
            if(ModelState.IsValid)
            {
                _dbContext.VillaNumbers.Add(villaNumber.VillaNumber);
                _dbContext.SaveChanges();
                TempData["Success"] = "VillaNumber Created Sucessfully";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Could Not Create Villa Number";
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
