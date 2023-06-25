using Microsoft.EntityFrameworkCore;
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
        public void Insert(Seller s)
        {
            //s.Department = _context.Department.First(); //evita bug inicial FK department id null
            //Add é feito em memória, não acessa o banco, então não precisa colocar assíncrono, colocar só no SaveChanges
            _context.Add(s);
             _context.SaveChanges();
        }
        public Seller FindById(int id)
        {
            return _context.Seller.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
        }
        public void Remove(int id)
        {
            var s = _context.Seller.Find(id);
            _context.Seller.Remove(s);
            _context.SaveChanges();
        }
    }
}
