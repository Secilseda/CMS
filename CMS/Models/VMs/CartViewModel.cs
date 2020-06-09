using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.VMs
{
	public class CartViewModel
	{
		public List<CartItem> CartItems { get; set; }
		public decimal GrandTotal { get; set; }//toplam 
	}
}
