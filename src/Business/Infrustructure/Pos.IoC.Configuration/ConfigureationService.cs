using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pos.Core.Mapper;
using Pos.Infrustructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.IoC.Configuration
{
   public static  class ConfigureationService
    {
		public static IServiceCollection AddExtention(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<PosDbContext>(options =>
			   options.UseSqlServer(configuration.GetConnectionString("Conn")
				   ));

            services.AddAutoMapper(typeof(CommonMapper).Assembly);


            //	services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(ICore).Assembly));

            //services.AddMediatR(cfg =>
            //{
            //	cfg.RegisterServicesFromAssemblies(typeof(ICore).Assembly);

            //});



            return services;
		}
	}
}
