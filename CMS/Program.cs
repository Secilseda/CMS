using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure.Seeding;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CMS
{
	public class Program
	{
		public static void Main(string[] args)//proje ilk çalıştırdığımızda
		{
			var host = CreateHostBuilder(args).Build();//services işlemi gerçekleştircek
			using (var scope=host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					SeedData.Initialize(services);
				}
				catch (Exception)
				{

					throw;
				}
			};
				host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
