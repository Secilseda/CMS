using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure.Attributes;
using CMS.Infrastructure.Context;
using CMS.Models;
using CMS.Models.VMs;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{ //sepetle ilgili işlemleri yapacağız.
    public class CartController : Controller
    {
        private readonly ProjectContext _context;
        public CartController(ProjectContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();//SessionExtensions'ta yazdığımız tip dönüştürme metodu olan GetJson'ı burada CartItem üzerinde kullanarak dönüştürüyoruz.

            CartViewModel cartVM = new CartViewModel
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Price * x.Quantity)//fiyat çarpı miktarı topla.
            };

            return View(cartVM); 
        }
        public async Task<IActionResult>Add(int id)//add'e view eklememize gerek yok çünkü product'ın ındex'ınden buradaki metoda erişicez.
        {
            Product product = await _context.Products.FindAsync(id);//id yakalanı

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();//sorguyu attı

            CartItem cartItem = cart.Where(x => x.ProductId == id).FirstOrDefault();
            if (cartItem==null)
            {
                cart.Add(new CartItem(product));//new'leyerek bize product'ı ekliyo.

            }
            else
            {
                cartItem.Quantity += 1;
            }
            //ekleme operasyonumuz.
            HttpContext.Session.SetJson("Cart", cart);
            if (HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")//giden requestin yani talebin başlığı vardır.(Headers)
            {
                return RedirectToAction("Index");
            }
            return ViewComponent("SmallCart");
        }

        public IActionResult Decrease(int id)//Azaltmak.
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            CartItem cartItem = cart.Where(x => x.ProductId == id).FirstOrDefault();

            if (cartItem.Quantity>1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(x => x.ProductId == id);
            }
            if (cart.Count==0)//cartItem liste tipinde olduğu için count'gelebilir saymak için. Hazır yapıdır.
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>> ("Cart");

            cart.RemoveAll(x => x.ProductId == id);

            if (cart.Count==0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else//cart'ın countu 0 değilse Setjson edicek
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");
            if (HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
            {
                return Redirect(Request.Headers["Referer"].ToString());
            }
            return Ok();
        }
    }
}