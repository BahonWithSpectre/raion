using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using raion.Models.apiModels;
using raion.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace raion.Controllers.Rest_Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private DbAppContext db;
        private UserManager<User> um;
        private SignInManager<User> sm;
        
        public AuthController(DbAppContext _db, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            db = _db;
            um = userManager;
            sm = signInManager;
        }


        [HttpPost]
        [Route("login")]
        public async Task<JsonResult> Login([FromBody] Login model)
        {
            if (ModelState.IsValid)
            {
                var result = await sm.PasswordSignInAsync(model.login, model.password, false, false);
                if (result.Succeeded)
                {
                    var user = await um.FindByNameAsync(model.login);
                    return new JsonResult(new Error { id = user.Id });
                }
            }
            return new JsonResult(new Error { error = "Данные отсутствуют" });
        }



        [HttpPost]
        [Route("register")]
        public async Task<JsonResult> Register([FromBody] Register model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.login, UserName = model.login, FirstName = model.Name, LastName = model.SurName };
                var result = await um.CreateAsync(user, model.password);

                if (result.Succeeded)
                {
                    return new JsonResult(new Error { id = user.Id });
                }
            }
            return new JsonResult(new Error { error = "Данные отсутствуют" });
        }
    }
}
