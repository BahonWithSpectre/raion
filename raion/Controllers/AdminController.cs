using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using raion.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace raion.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private DbAppContext db;
        private UserManager<User> userManager;

        public AdminController(DbAppContext _db, UserManager<User> um)
        {
            db = _db;
            userManager = um;
        }



        public async Task<IActionResult> Index()
        {
            return View(await userManager.Users.ToListAsync());
        }
    }
}
