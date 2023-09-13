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
            builder.HasData(

                new  { Id = 1, ProductName = "Apple",CreatedBy="1",Created=DateTimeOffset.Now,Status=EntityStatus.Created},new { Id = 2, ProductName = "Mango", Created = DateTimeOffset.Now, CreatedBy = "1",Status = EntityStatus.Created}



                );
        }
    }
}
