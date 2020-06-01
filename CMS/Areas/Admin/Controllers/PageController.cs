using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure.Context;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Areas.Admin.Controllers
{
    
    [Area("Admin")]//admin areasında çalıştığını belli edicez bu controller'in
    public class PageController : Controller
    {
        private readonly ProjectContext _context;
        //sadece okunabilir bi şekilde olucak=readonly
        public PageController(ProjectContext context)
        {
            this._context=context;

            //dışarıdan erişimi olmayan _contex'i context nesnemizle property'lerine erişiyoruz.
        }
        //twitter örneği gibi tweet atınca  yandaki paneller sabit kalıyor.
        //tasklar çalışırken birbirlerini beklemiyorlar. Çoklu iş yapılabiliyor.
        public async Task<IActionResult> Index()
            
            //async programlama:birbirinden bağımsız bileşenler olarak sayfaların çalışmasını sağlıyor, aynı anda bi kaç işlemi yapabiliriz.
            //Layout'umuzda async olarak tanımlayacağız.
        {
            //IQueryable<Page> pages=await _context.Pages.OrderBy(x=>x.Sorting);

            IQueryable<Page> pages = from p in _context.Pages orderby p.Sorting select p;

            //listeledik bir şeyleri hazırda tutuyor IQueryable . İhtiyaç olduğunda çağırıyoruz. Sürekli db'ye gitmiyoruz.
            //IQueryable filtreleme mekanizması var.
            //IEnumerable 1000 kişiyi ram'çıkarıp sonra çağırıyor.

            List<Page> pageList = await pages.ToListAsync();
            return View(pageList);

            //return View(await _context.Pages.OrderBy(x => x.Sorting).ToListAsync());
            //IEnumerable ve IQueryable arasındaki en büyük fark IEnumerable tipinin datayı önce belleğe atıp ardından koşulları bellekteki dataya uygulamasıdır. IQueryable tipinde ise sorgular direkt olarak sql servere yapılır.
        }
        public async Task<IActionResult>Details(int id)
        {
            Page page = await _context.Pages.FirstOrDefaultAsync(x => x.Id == id);
            if (page==null)
            {
                return NotFound();
            }
            return View(page);
        }
        public IActionResult Create() => View();//sayfayı getirecek klasik mvc mantığı.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Title.ToLower().Replace(" ","-");//gelen page'e slug ürettik.boşluk gördüğün yerlere - ekle.
                page.Sorting = 100;

                var slug = await _context.Pages.FirstOrDefaultAsync(x => x.Slug == page.Slug);//db'de varsa slug doldu
                //Await=bekletme anlamında.
                if (slug!=null)//yoksa
                {
                    ModelState.AddModelError("", "The page already exists..!");
                    return View(page);

                }
                _context.Add(page);
                await _context.SaveChangesAsync();//sürekli db'ye göndermek doğru değil.
                TempData["Success"] = "The page has been added..!";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "The page hasn't been added..!";
                return View(page);
            }
        }
        public async Task<IActionResult>Edit(int id)//create gibi yakalama operasyonu yapıcaz
        {
            Page page = await _context.Pages.FindAsync(id);
            if (page==null)
            {
                NotFound();
            }
            return View(page);//yakaladığım page'i dön
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(Page page)
        {
            if (ModelState.IsValid)
            {
                //home ise update edilmeyecek.
                page.Slug = page.Id == 1 ? "home" : page.Title.ToLower().Replace(" ", "-");//if sorgusu
                //slug ıd'si 1 ya da home ise demek.
                //İnsted if (?)
                var slug = await _context.Pages.Where(x => x.Id != page.Id).FirstOrDefaultAsync(x => x.Slug == page.Slug);//doldurduk.

                if (slug !=null)//içiini doldurduğun slug'in içi nullsa
                {
                    ModelState.AddModelError("", "The home page can't edit..!");
                    return View(page);
                }

                _context.Update(page);
                await _context.SaveChangesAsync();
                TempData["Succes"] = "The page has been edit..!";
                return RedirectToAction("Edit", new { id = page.Id });
            }
            else
            {
                TempData["Error"] = "The page hasn't been edit..!";
                return View(page);
            }
        }
    }
}