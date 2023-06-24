using WebApplicationMVC.Models;

namespace WebApplicationMVC.Services
{
    public class SellerService
    {
        private readonly WebApplicationMVCContext _context;// readonly para nunca ser alterada

        public SellerService(WebApplicationMVCContext context)
        {
            _context = context;
        }
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
            // acessará o DbSet<Seller> no contexto e tras os dados como lista deve ser assincrona pois vai demorar aleatoriamente
        }
    }
}
