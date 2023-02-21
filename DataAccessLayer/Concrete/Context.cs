using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("server=DESKTOP-CP2KTK6;database=StokTakipCore;integrated security=true;");

        }

        public DbSet<Stores> Stores { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Stok> Stoks { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<WebConfig> webConfigs { get; set; }

    }
}
