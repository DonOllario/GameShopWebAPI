using GameShopWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.EntityConfigurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .HasKey(a => a.AddressId);
            builder
                .Property(a => a.AddressId)
                .UseIdentityColumn(1, 1)
                .IsRequired();

            builder
                .Property(a => a.StreetAddress)
                .IsRequired();

            builder
                .Property(a => a.City)
                .IsRequired();

            builder
                .Property(a => a.PostalCode)
                .IsRequired();

            //Relations--------------------------------

            builder
                .HasMany(a => a.Stores)
                .WithOne(s => s.Address)
                .HasForeignKey(a => a.StoreId);

            builder
                .HasMany(a => a.Customers)
                .WithOne(c => c.Address)
                .HasForeignKey(a => a.CustomerId);

            builder
                .HasMany(a => a.Employees)
                .WithOne(e => e.Address)
                .HasForeignKey(a => a.EmployeeId);
        }
    }
}
