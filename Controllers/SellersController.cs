using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models;
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
            // O controlador de Seller controla os Services do Model Seller como usando o findall
        }
        public IActionResult Create()
        {
            // tipo GET
            return View();
        }

        [HttpPost] //annotation para ser POST
        [ValidateAntiForgeryToken]//anti ataques csrf - impedir injeçoes com minha autenticação
        public IActionResult Create(Seller s)
        {
            _sellerService.Insert(s);
            // usando o serviço insert após o GET na pagina
            // esse .Insert por sua vez usa o POST
            return RedirectToAction(nameof(Index));
            // nameof(função) vai retornar o para a ação que leva para a pagina Index
            // isso independente de trocar o nome da pagina de Index para outro nome com Home
        }
    }
}
