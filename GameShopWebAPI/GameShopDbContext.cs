using GameShopWebAPI.EntityConfigurations;
using GameShopWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI
{
    public class GameShopDbContext : DbContext
    {

        public GameShopDbContext(DbContextOptions<GameShopDbContext> options) : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder
                .ApplyConfiguration(new AddressConfiguration());
            modelBuilder
                .ApplyConfiguration(new CustomerConfiguration());
            modelBuilder
                .ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder
                .ApplyConfiguration(new GameConfiguration());
            modelBuilder
                .ApplyConfiguration(new GenreConfiguration());
            modelBuilder
                .ApplyConfiguration(new OrderConfiguration());
            modelBuilder
                .ApplyConfiguration(new OrderLineConfiguration());
            modelBuilder
                .ApplyConfiguration(new StoreConfiguration());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
