using GameShopWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.EntityConfigurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder
                .HasKey(g => g.GenreId);
            builder
                .Property(g => g.GenreId)
                .UseIdentityColumn(1,1)
                .IsRequired();

            builder
                .Property(g => g.GenreName)
                .IsRequired();

            builder
                .Property(g => g.GenreDescription)
                .IsRequired(false);

            //Relations--------------------------------
            builder
                .HasMany(ge => ge.Games)
                .WithMany(ga => ga.Genres);
        }
    }
}
