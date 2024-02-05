using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            var villas = _dbContext.Villas.ToList();    
           return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
