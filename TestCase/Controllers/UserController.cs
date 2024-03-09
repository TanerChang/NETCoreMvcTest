using Microsoft.AspNetCore.Mvc;
using static TestCase.Parameter.SearchModel.UserSearchModel;

namespace TestCase.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidateLogin(User U)
        {
           

                // 登入成功，導向到首頁或其他頁面
                return RedirectToAction("Index", "Home");
            
                // 登入失敗，重新導向到登入頁面
                return RedirectToAction("Login");
            
        }
    }
}
