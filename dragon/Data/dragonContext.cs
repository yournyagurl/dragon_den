using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dragon.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace dragon.Data
{
    public class dragonContext : IdentityDbContext<AppUser>
    {
        public dragonContext (DbContextOptions<dragonContext> options)
            : base(options)
        {
        }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Ad> Ads { get; set; }
        public DbSet<Cat> Category { get; set; }

        public DbSet<CheckoutCustomers> CheckoutCustomers { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<BasketItem> BasketItems { get; set; }

        public DbSet<OrderHistory> OrderHistorys { get; set; }

        public DbSet<ItemsOrders> itemsOrders { get; set; }

        public DbSet<ContactCentre> ContactCentres { get; set; }


        [NotMapped] public DbSet<CheckoutItem> CheckoutItems { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Dish>().ToTable("Dish");

            builder.Entity<BasketItem>().HasKey(t => new { t.DishId, t.BasketId });

        }

    }
}
