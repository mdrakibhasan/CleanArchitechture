using Microsoft.EntityFrameworkCore;
using System;

namespace Pos.Infrustructure
{
    public class PosDbContext:DbContext
    {
		public PosDbContext(DbContextOptions<PosDbContext> options) : base(options)
		{


		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(PosDbContext).Assembly);
		}

	}
}
