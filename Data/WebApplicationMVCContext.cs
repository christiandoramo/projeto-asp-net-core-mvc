using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Data
{
    public class WebApplicationMVCContext : DbContext
    {
        public WebApplicationMVCContext (DbContextOptions<WebApplicationMVCContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationMVC.Models.Department> Department { get; set; } = default!;

        public DbSet<WebApplicationMVC.Models.SalesRecord> SalesRecord { get; set; } = default!;

        public DbSet<WebApplicationMVC.Models.Seller> Seller { get; set; } = default!;


    }
}
