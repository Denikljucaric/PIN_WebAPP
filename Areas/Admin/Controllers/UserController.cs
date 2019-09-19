using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PIN_WebAPP.Data;
using Microsoft.EntityFrameworkCore;
using PIN_WebAPP.Utility;
using Microsoft.AspNetCore.Authorization;

namespace PIN_WebAPP.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class UserController : Controller
    {

        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task< IActionResult> Index()
        {
            var claimsIdenity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdenity.FindFirst(ClaimTypes.NameIdentifier);

            return View(await _db.User.Where(u => u.Id != claim.Value).ToListAsync());
        }
    }
}