using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CMS.Infrastructure.Context;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Controllers
{
    public class PageController : Controller
    {
        private readonly ProjectContext _context;
        public PageController(ProjectContext context)
        {
            this._context = context;

        }
        // /page / or/slug=url bu şekilde olacak.
        public async Task<IActionResult> Page(string slug)
        {
            if (slug==null)
            {
                return View(await _context.Pages.Where(x => x.Slug == "home").FirstOrDefaultAsync());
            }
            Page page = await _context.Pages.Where(x => x.Slug == slug).FirstOrDefaultAsync();
            if (page==null)
            {
                return NotFound();
            }
            return View();
        }
    }
}