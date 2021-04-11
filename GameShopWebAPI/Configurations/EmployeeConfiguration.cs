using GameShopWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopWebAPI.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .HasKey(e => e.EmployeeId);
            builder
                .Property(e => e.EmployeeId)
                .UseIdentityColumn(1, 1);

            builder
                .Property(e => e.EmployeeNumber)
                .ValueGeneratedOnAdd();

            builder
                .Property(e => e.FirstName)
                .IsRequired();

            builder
                .Property(e => e.LastName)
                .IsRequired();

            builder
                .Property(e => e.Email)
                .IsRequired();

            builder
                .Property(e => e.PhoneNumber)
                .IsRequired();

            builder
                .Property(e => e.EmploymentDate)
                .ValueGeneratedOnAdd()
                .IsRequired();

            //Relations--------------------------------
            
            builder
                .HasOne(e => e.Address)
                .WithMany(a => a.Employees)
                .HasForeignKey(e => e.AddressId);

            builder
                .HasMany(e => e.Stores)
                .WithMany(s => s.Employees);
                

            builder
                .HasMany(e => e.Orders)
                .WithOne(o => o.Employee)
                .HasForeignKey(e => e.EmployeeId);
        }
    }
}
