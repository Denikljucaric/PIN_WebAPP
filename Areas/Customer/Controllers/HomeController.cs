using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIN_WebAPP.Data;
using PIN_WebAPP.Models;
using PIN_WebAPP.Models.ViewModels;
using PIN_WebAPP.Utility;

namespace PIN_WebAPP.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            IndexViewModel indexView = new IndexViewModel()
            {
                Product = await _db.Product.Include(m => m.Brand).Include(m => m.Category).Include(m => m.SubCategory).ToListAsync(),
                Category = await _db.Category.ToListAsync(),
                Brand= await _db.Brand.ToListAsync(),
                SubCategory = await _db.SubCategory.ToListAsync(),
                Carosel = await _db.Carosel.ToListAsync(),

            };

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                var cnt = _db.ShopingCart.Where(u => u.UserId== claim.Value).ToList().Count;
                HttpContext.Session.SetInt32("ssCartCpit", cnt);
            }

            return View(indexView);
        }
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var productFromDb = await _db.Product.Include(m => m.Category).Include(m => m.SubCategory).Where(m => m.Id == id).FirstOrDefaultAsync();
            ShopingCart cartObj = new ShopingCart()
            {
                Product = productFromDb,
                ProductId = productFromDb.Id
            };
            return View(cartObj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(ShopingCart CartObject)
        {
            CartObject.Id = 0;
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                CartObject.UserId = claim.Value;

                ShopingCart cartFromDb = await _db.ShopingCart.Where(c => c.UserId == CartObject.UserId
                                                && c.ProductId == CartObject.ProductId).FirstOrDefaultAsync();

                if (cartFromDb == null)
                {
                    await _db.ShopingCart.AddAsync(CartObject);
                }
                else
                {
                    cartFromDb.Count = cartFromDb.Count + CartObject.Count;
                }
                await _db.SaveChangesAsync();

                var count = _db.ShopingCart.Where(c => c.UserId == CartObject.UserId).ToList().Count();
                HttpContext.Session.SetInt32(SD.ssShoppingCartCount, count);

                return RedirectToAction("Index");
            }
            else
            {

                var menuItemFromDb = await _db.Product.Include(m => m.Category).Include(m => m.SubCategory).Where(m => m.Id == CartObject.ProductId).FirstOrDefaultAsync();

                ShopingCart cartObj = new ShopingCart()
                {
                    Product = menuItemFromDb,
                    ProductId = menuItemFromDb.Id
                };

                return View(cartObj);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
