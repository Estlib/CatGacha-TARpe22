using Microsoft.AspNetCore.Mvc;

namespace CatGacha.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
