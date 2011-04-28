using System.Data.Entity;
using Core.Model;

namespace Data
{
    public class Db : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Dinner> Dinners { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(System.Data.Entity.ModelConfiguration.ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dinner>().HasMany(r => r.Meals);
            modelBuilder.Entity<User>().HasMany(r => r.Roles);
            modelBuilder.Entity<Vendor>().HasMany(r => r.Coupons);
            base.OnModelCreating(modelBuilder);
        }
    }
}