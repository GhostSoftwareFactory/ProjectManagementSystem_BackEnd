using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementAPI.Controllers
{
    public class BoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
