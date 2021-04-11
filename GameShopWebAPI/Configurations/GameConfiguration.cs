using GameShopWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.EntityConfigurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
                .HasKey(ga => ga.GameId);
            builder
                .Property(ga => ga.GameId)
                .UseIdentityColumn(1,1)
                .IsRequired();

            builder
                .Property(ga => ga.GameName)
                .IsRequired();

            builder
                .Property(ga => ga.GameDescription)
                .IsRequired(false);

            builder
                .Property(ga => ga.GamePrice)
                .IsRequired();

            builder
                .Property(ga => ga.ReleaseDate)
                .IsRequired();

            //Relations--------------------------------
            builder
                .HasMany(ga => ga.Genres)
                .WithMany(ge => ge.Games);

            builder
                .HasMany(g => g.OrderLines)
                .WithMany(ol => ol.Games);
        }
    }
}
