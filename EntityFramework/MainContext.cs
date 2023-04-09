using Microsoft.EntityFrameworkCore;
using StokTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.EntityFramework
{
    internal class MainContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Changed> Changed { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=StokTakip;User Id=hafta5;Password=123456789");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
