using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
               .HasKey(p => p.Id);

            builder
                 .HasOne(p => p.Category)
                 .WithMany(c => c.Products)
                 .HasForeignKey(p => p.Category_Id)
                 .OnDelete(DeleteBehavior.Restrict);

            builder
            .Property(p => p.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(180);

            builder
                .Property(p => p.Description)
                .IsRequired()
                .HasColumnType("text")
                .HasMaxLength(1024);

            builder
                .Property(p => p.Value)
                .IsRequired()
                .HasColumnType("decimal(18,4)");

            builder
                .Property(p => p.Brand)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(80);
        }
    }
    
}
