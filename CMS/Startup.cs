using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure.Context;
using CMS.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CMS
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)//kullan�c� taraf�nda olacak i�lemler.
		{
			services.AddMemoryCache();
			services.AddSession(options=>
			{
				//options.IdleTimeout = TimeSpan.FromSeconds(2);
				//options.IdleTimeout = TimeSpan.FromDays(2);//2 g�n sonra gitsin 10 g�n sonra gitsin gibi i�lemler.
			});

			services.AddControllersWithViews();
			//database'e ba�lanma
			services.AddDbContext<ProjectContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<AppUser, IdentityRole>(options=> {
				options.Password.RequiredLength = 4;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireDigit = false;
			  })//addIdenttiy ekledik.
				.AddEntityFrameworkStores<ProjectContext>()
				.AddDefaultTokenProviders();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();
			app.UseSession();//session kulland���m�z� belli ettik.

			app.UseAuthentication();
			app.UseAuthorization();
			

			app.UseEndpoints(endpoints =>
			{
			endpoints.MapControllerRoute(
				"page",
				"{slug?}",
				defaults: new { controller = "Page", action = "Page" });//bir �ey vermezsek bu �al��acak.

				endpoints.MapControllerRoute(
					   "product",
					   "product/{categorySlug}",
					   defaults: new { controller = "Product", action = "ProductsByCategory" });

				endpoints.MapControllerRoute(//ekledi�imiz areasa dair rooting'imiz.
					   name: "areas",
					   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
