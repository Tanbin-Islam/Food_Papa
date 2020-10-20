using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodsPapa.Models
{
    public class FoodDbContext:IdentityDbContext<ApplicationUser>
    {
        public FoodDbContext(DbContextOptions<FoodDbContext>options):base(options)
        {

        }
        public DbSet<Food> foods { get; set; }
        public DbSet<OrderOnline> orderOnlines { get; set; }
        public DbSet<Member> members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
   
}
