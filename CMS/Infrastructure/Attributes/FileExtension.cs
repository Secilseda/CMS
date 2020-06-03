using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Attributes
{
	public class FileExtension: ValidationAttribute//ValidationAttribute'den kalıtım alıyor.
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var file = value as IFormFile;//uzantıya bakıcak 

			if (file!=null)//null değilse
			{
				var extention = Path.GetExtension(file.FileName);

				string[] extensions = { ".jpg", ".png" };

				bool result = extensions.Any(x => x.EndsWith(x));//EndsWith=sonuna bakıyor.

				if (!result)
				{
					return new ValidationResult("Allowed extensions are jpg and png");
				}
			}
			return ValidationResult.Success;
		}
		
	}
}
