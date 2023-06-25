using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplicationMVC.Models;
using WebApplicationMVC.Services;
using WebApplicationMVC.Models.ViewModels;

namespace WebApplicationMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
            // chamando view com nome Index em View  Sellers por causa do nome Sellers em action, o qual também chamou Sellers"Controller"
            // retornando lista do service seller e não desse controlador
            // O controlador de Seller controla os Services do Model Seller como usando o findall
        }

        // tipo GET
        public IActionResult Create()
        {
            // vai entrar na pagina Create pelo metodo, e depois mandará o novo Seller para o Create abaixo com Sobrecarga
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
            //a View vai vim com os departamentos carregados
        }

        [HttpPost] //annotation para ser POST
        [ValidateAntiForgeryToken]//anti ataques csrf - impedir injeçoes com minha autenticação
        public IActionResult Create(Seller s)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerFormViewModel { Seller = s, Departments = departments };
                return View(viewModel);
            }
            _sellerService.Insert(s);
            // usando o serviço insert após o GET na pagina
            // esse .Insert por sua vez usa o POST
            return RedirectToAction(nameof(Index));
            // nameof(função) vai retornar o para a ação que leva para a pagina Index
            // isso independente de trocar o nome da pagina de Index para outro nome com Home
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
