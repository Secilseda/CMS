using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{ //DTO gibi kullanacağız AppUser'ı burada User'da ayağa kaldırıcaz diyebiliriim.
	public class User
	{
		//AppUserdan ihtiyacımız olanları aldık klasik DTO mantığını kullandık.
		[Required]
		[MinLength(2,ErrorMessage ="Minimum lenght is 2")]
		[Display(Name ="User Name")]//türkçeye dönecekse display.
		public string UserName { get; set; }

		[Required,EmailAddress]
		public string Email { get; set; }

		[DataType(DataType.Password),Required,MinLength(4,ErrorMessage ="Minimum lenght is 4")]//enum çağırdık password olduğunu belirttik.
		public string Password { get; set; }

		
	}
}
