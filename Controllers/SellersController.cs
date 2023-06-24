using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Services;

namespace WebApplicationMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
            // chamando view com nome Index em View  Sellers por causa do nome Sellers em action, o qual também chamou Sellers"Controller"
            // retornando lista do service seller e não desse controlador
            // O controlador de Seller controla os Services do Model Seller com usando o findall
        }
    }
}
