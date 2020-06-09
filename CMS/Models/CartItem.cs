using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{
	public class CartItem
	{//sanal bir gerçeklik oluşturacağız.
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public decimal Total { get { return Quantity * Price; }}
		public string Image { get; set; }
		
		public CartItem()
		{ }//alma işlemini gerçekleştiriyor
		public CartItem(Product product)//atama işlemini gerçekleştiriyor.
		{
			ProductId = product.Id;
			ProductName = product.Name;
			Quantity = 1;
			Image = product.Image;
		}
	}
}
