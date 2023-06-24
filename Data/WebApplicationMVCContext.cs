using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// mudei o namespace apenas para facilitar a escrita dos tipos DbSet<>
namespace WebApplicationMVC.Models
{
    public class WebApplicationMVCContext : DbContext
        // essa classe representa o contexto das dependencias do DB
    {
        public WebApplicationMVCContext(DbContextOptions<WebApplicationMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;

        public DbSet<SalesRecord> SalesRecord { get; set; } = default!;

        public DbSet<Seller> Seller { get; set; } = default!;


    }
}
