using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMVC.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            // chamando view c nome Index em View  Sellers por causa do nome Sellers em action, o qual também chamou Sellers"Controller"
            return View();
        }
    }
}
