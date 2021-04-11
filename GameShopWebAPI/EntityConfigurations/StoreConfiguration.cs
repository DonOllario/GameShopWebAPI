using GameShopWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.EntityConfigurations
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder
                .HasKey(s => s.StoreId);
            builder
                .Property(s => s.StoreId)
                .UseIdentityColumn(1, 1);

            //Relations--------------------------------
            builder
                .Property(s => s.AddressId)
                .IsRequired();
            builder
                .HasOne(s => s.Address)
                .WithMany(a => a.Stores)
                .HasForeignKey(s => s.AddressId);

            builder
                .HasMany(a => a.Employees)
                .WithMany(e => e.Stores);
        }
    }
}
