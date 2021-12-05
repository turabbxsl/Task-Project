using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=Task2; integrated security=true;");
        }

        public DbSet<Client> Clients{ get; set; }
        public DbSet<Loan> Loans{ get; set; }
        public DbSet<Invoices> Invoices{ get; set; }
    }
}
