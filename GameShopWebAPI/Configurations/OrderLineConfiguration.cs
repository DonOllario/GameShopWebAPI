using GameShopWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.EntityConfigurations
{
    public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {

            builder
                .HasKey(ol => ol.OrderLineId);
            builder
                .Property(ol => ol.OrderLineId)
                .UseIdentityColumn(1,1)
                .IsRequired();

            builder
                .Property(ol => ol.Quantity)
                .IsRequired();

            //Relations--------------------------------
            
            builder
                .HasOne(ol => ol.Order)
                .WithMany(o => o.OrderLines)
                .HasForeignKey(ol => ol.OrderId);

            builder
                .HasOne(ol => ol.Game)
                .WithMany(o => o.OrderLines);
        }
    }
}
