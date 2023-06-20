using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
            // o nome da view deve ser Index tbm
        {
            List<Department> lista = new List<Department>();
            lista.Add(new Department {  Id = 1, Name = "Eletronics"});
            lista.Add(new Department { Id = 2, Name = "Fashion" });
            lista.Add(new Department { Id = 3, Name = "Utilitaries" });
            return View(lista);
            // para enviar a lista ^^^^
        }
    }
}
