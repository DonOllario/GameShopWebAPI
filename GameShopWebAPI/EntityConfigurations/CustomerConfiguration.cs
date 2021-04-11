using GameShopWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(c => c.CustomerId);
            builder
                .Property(c => c.CustomerId)
                .UseIdentityColumn(1,1)
                .IsRequired();

            builder
                .Property(c => c.FirstName)
                .IsRequired();

            builder
                .Property(c => c.LastName)
                .IsRequired();

            builder
                .Property(c => c.Email)
                .IsRequired();

            builder
                .Property(c => c.PhoneNumber)
                .IsRequired(false);

            builder
                .Property(c => c.CreationDate)
                .IsRequired();

            //Relations--------------------------------
            
            builder
                .HasOne(c => c.Address)
                .WithMany(a => a.Customers)
                .HasForeignKey(c => c.AddressId);

            builder
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(c => c.CustomerId);
        }
    }
}
