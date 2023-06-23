
namespace WebApplicationMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();
        //coleção bem generica para ficar mais facil de mexer

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Department()
        {
        }


        public void AddSellers(Seller s)
        {
            Sellers.Add(s);
        }
        public void RemoveSales(Seller s)
        {
            Sellers.Remove(s);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(s => s.TotalSales(initial, final));
            // operações LINQ usando expressão lambda
        }
    }
}
