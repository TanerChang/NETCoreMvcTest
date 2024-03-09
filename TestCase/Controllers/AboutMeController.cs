using Microsoft.AspNetCore.Mvc;
using TestCase.DataAccessLayer;
using TestCase.DataAccessLayer.Provider;

namespace TestCase.Controllers
{
    public class aboutMeController : Controller
    {
        private readonly MvcDBContext _context;
        public aboutMeController(MvcDBContext context)
        {
            _context = context;
        }
        public IActionResult aboutMe()
        {
            var LISE = _context.M_Note.ToList();
            return View(LISE);
            //return View();
        }
    }
}
