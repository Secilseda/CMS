using CMS.Infrastructure.Attributes;
using CMS.Models;
using CMS.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Components
{
	public class SmallCartViewComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
			SmallCartViewModel smallCartVM;

			if (cart==null || cart.Count==0)
			{
				smallCartVM = null;
			}
			else
			{
				smallCartVM = new SmallCartViewModel
				{
					NumberofItems = cart.Sum(x => x.Quantity),
					TotalAmount = cart.Sum(x => x.Quantity * x.Price)
				};
			}
			return View(smallCartVM);
		}
	}
}
