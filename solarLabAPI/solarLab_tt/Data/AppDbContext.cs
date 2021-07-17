using Microsoft.EntityFrameworkCore;
using solarLab_tt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solarLab_tt.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> Person {set; get;}
        public DbSet<Address> Addresses {set; get;}
    }
}
