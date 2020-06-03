using CMS.Infrastructure.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{
	public class Product:BaseEntity
	{
		
		[MinLength(2,ErrorMessage ="Minimum lenght is 2")]
		public string Name { get; set; }

		public string Slug { get; set; }
		[Required]
		[MinLength(2, ErrorMessage = "Minimum lenght is 2")]
		public string Description { get; set; }

		[Column(TypeName ="decimal(18,2)")]//format verdik 
		public decimal Price { get; set; }

		public string Image { get; set; }

		[NotMapped]//tabloda ayağa kalkmayacak.
		[FileExtension]//resim uzantısı (kendimiz yazdık)
		public IFormFile ImageUpload { get; set; }

		[Display(Name="Category")]
		[Range(1,int.MaxValue, ErrorMessage ="You must choose a category")]
		public int CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		public virtual Category Category { get; set; }
	}
}
