using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure.Context;
using CMS.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ProjectContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;//Resim yükleme ve kaldırma gibi operasyonlarda yardımcı olacak bize. Server tarafı gibi düşünülebilir.

        public ProductController(ProjectContext context,IWebHostEnvironment webHostEnvironment)
        {
            this._context = context;
            this._webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult>Index()
        {
            return View(await _context.Products.Include(x => x.Category).ToListAsync());
        }
        public IActionResult Create()
        {
            //her productın bir kategorisi olur.
            ViewBag.CategoryId = new SelectList(_context.Categories.OrderBy(x => x.Sorting), "Id", "Name");
            return View();//
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            ViewBag.CategoryId = new SelectList(_context.Categories.OrderBy(x => x.Sorting), "Id", "Name");//view bag'e categorymizde istediklerimizi çağırıyoruz. selectlist le listeleyip linq to sorguları atıyoruz.
            if (ModelState.IsValid)
            {
                product.Slug = product.Name.ToLower().Replace(" ", "-");
                var slug = await _context.Products.FirstOrDefaultAsync(x => x.Slug == product.Slug);
                if (slug!=null)
                {
                    ModelState.AddModelError("", "The product already exists..!");
                    return View(product);
                }
                string imageName = "noimage.png";//image nesnesine default değer atadık.
                if (product.ImageUpload!=null)
                {
                    //Dir dizin yapısıdır.
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath,"media/products");
                    // Guid, benzersiz değerler oluşturmak için kullanılmaktadır. Örnek olarak ortak bir alana birden fazla kullanıcının dosya kaydetmesini gösterebiliriz. ... Guid yapısı ise bize benzersiz değerler üretir ve böyle bir durumun oluşmamasını sağlar.
                    //her bir resim yükleme işlemi esnasında 
                    imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadDir, imageName);
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await product.ImageUpload.CopyToAsync(fs);
                    fs.Close();

                }
                product.Image = imageName;
                _context.Add(product);
                await _context.SaveChangesAsync();
                TempData["Success"] = "The product has been added..!";
            }
            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product==null)
            {
                return NotFound();
            }
            ViewBag.CategoryId = new SelectList(_context.Categories.OrderBy(x => x.Sorting), "Id", "Name",product.CategoryId);//database üretilen product.categoryıd getirilmesi gerekiyor.

            return View(product);
        }
        [HttpPost]//güncelleme=Edit
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            ViewBag.CategoryId = new SelectList(_context.Categories.OrderBy(x => x.Sorting), "Id", "Name", product.CategoryId);
            if (ModelState.IsValid)
            {
                product.Slug = product.Name.ToLower().Replace(" ", "-");
                var slug = await _context.Products.Where(x => x.Id != id).FirstOrDefaultAsync(x => x.Slug == product.Slug);

                if (slug!=null)
                {
                    ModelState.AddModelError("", "The product already exsist..!");
                    return View(product);
                }

                if (product.ImageUpload!=null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath,"media/products");//kök yolu kullanarak combine edicez.
                    if (!string.Equals(product.Image,"noimage.png"))//image yeniyse crud operasyonları olucak değilse alttaki kodlar çalışacak.
                    {
                        string oldImagePath = Path.Combine(uploadDir, product.Image);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);//eski imagepath gidiyor.
                        }
                    }
                    string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;//yeni fotoğraf ekliyoruz.üretilen guid ile productın upload image oluşturuken _ kooyduk.
                    string filePath = Path.Combine(uploadDir, imageName);
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await product.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    product.Image = imageName;

                }
                _context.Update(product);

                await _context.SaveChangesAsync();

                TempData["Success"] = "The product has been edited..!";

                return RedirectToAction("Index");
            }
            TempData["Error"] = "The product hasn't been edited..!";

            return View(product);
        }
        public async Task<IActionResult>Delete(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product==null)
            {
                TempData["Warning"] = "The product does not exisits..!";
            }
            else
            {
                if (!string.Equals(product.Image,"noimage.png"))
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");
                    string oldImagePath = Path.Combine(uploadDir, product.Image);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                _context.Remove(product);
                await _context.SaveChangesAsync();
                TempData["Success"] = "The product has been removed..!";

            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>Details(int id)
        {
            Product product = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (product==null)
            {
                return NotFound();
            }
            return View(product);
        }

    }
}