using WebApplicationMVC.Models;

namespace WebApplicationMVC.Services
{
    public class DepartmentService
    {
        private readonly WebApplicationMVCContext _context;// readonly para nunca ser alterada

        public DepartmentService(WebApplicationMVCContext context)
        {
            _context = context;
        }
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(d => d.Name).ToList();
            // acessará o DbSet<Seller> no contexto e tras os dados como lista deve ser assincrona pois vai demorar aleatoriamente
        }
        public void Insert(Department d)
        {
            _context.Add(d);
            _context.SaveChanges();
        }
    }
}
