using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Model;
using Pos.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Infrustructure.Persistance.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.BarCode).IsUnique();
            builder.Property(a => a.BarCode).IsRequired();
            builder.HasData(

                new  { Id = 1, ProductName = "Apple", BarCode="0001", CreatedBy="1", ItemId=1, Created=DateTimeOffset.Now,Status=EntityStatus.Created},new { Id = 2, ProductName = "Mango", BarCode = "0002", ItemId = 2, Created = DateTimeOffset.Now, CreatedBy = "1",Status = EntityStatus.Created}



                );
        }
    }
}
