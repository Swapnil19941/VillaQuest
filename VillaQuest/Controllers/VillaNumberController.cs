using Microsoft.AspNetCore.Mvc;
using VillaQuest.Domain.Entities;
using VillaQuest.Infrastrucutre.Data;

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
