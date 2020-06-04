using CMS.Infrastructure.Context;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Components
{
	public class MainMenuViewComponent:ViewComponent
	{//loyautta olıuşan li'lerin buraya düşmesini sağlıyor.
		private readonly ProjectContext _context;
		public MainMenuViewComponent(ProjectContext context)
		{
			this._context = context;
		}
		public async Task<IViewComponentResult>InvokeAsync()//bir task altında bir çok işi eş zamnlıı olarak çağırabiliriz.
		{
			var pages = await GetPageAsync();//işide burada çağırdık.
			return View(pages);
		}
		private Task<List<Page>> GetPageAsync()//bir list tipinde task yarattık onları çağırdık.
		{
			return _context.Pages.OrderBy(x => x.Sorting).ToListAsync();
		}
		

	}
}
