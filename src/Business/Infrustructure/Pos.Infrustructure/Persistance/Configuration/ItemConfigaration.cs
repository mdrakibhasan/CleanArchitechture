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
    internal class ItemConfigaration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");

            builder.HasKey(x => x.Id);
            builder.HasData(

                new { Id = 1, Name = "Apple", CreatedBy = "1", Created = DateTimeOffset.Now, Status = EntityStatus.Created }, new { Id = 2, ProductName = "Mango", Created = DateTimeOffset.Now, CreatedBy = "1", Status = EntityStatus.Created }



                );
        }
    }
}
