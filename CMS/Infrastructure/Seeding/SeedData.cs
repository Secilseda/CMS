using CMS.Infrastructure.Context;
using CMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Seeding
{
	//test datasına ihtiyaç duyduğumzda tohumluyoruz.(seedDate)
	//Kayıtlı kimse yoksa adminleri ekler gireriz.(new page)
	public class SeedData//isteklere göre projeye gidip sayfalar ekleyecek.
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{ //using ile yaratıyoruz.
			using (var context = new ProjectContext(serviceProvider.GetRequiredService<DbContextOptions<ProjectContext>>()))
			{
				if (context.Pages.Any())//her hangi biri varsa return et.
				{
					return;
				}
				context.Pages.AddRange(//admin vs vs ekliyosun
					new Page
					{
						Title = "Home",
						Slug = "home",
						Content = "home page",
						Sorting = 0,
					},
					
				new Page
				{
					Title = "About Us",
					Slug = "about-us",
					Content = "about us page",
					Sorting = 100,
				},
				new Page
				{
					Title = "Services",
					Slug = "services",
					Content = "services page",
					Sorting = 200,
				},
				new Page
				{
					Title = "Contact",
					Slug = "contact",
					Content = "contact page",
					Sorting = 100,
				}
				);
				context.SaveChanges();
			}
		}
	}
}
