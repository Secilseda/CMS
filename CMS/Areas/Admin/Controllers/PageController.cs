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
    }
}