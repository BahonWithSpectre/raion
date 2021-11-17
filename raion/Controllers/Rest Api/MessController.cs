using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class MessController : ControllerBase
    {
        private DbAppContext db;
        private UserManager<User> um;
        private SignInManager<User> sm;

        public MessController(DbAppContext _db, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            db = _db;
            um = userManager;
            sm = signInManager;
        }



        [HttpPost]
        [Route("Write")]
        public async Task<JsonResult> MessTo([FromBody] MessModel model)
        {
            if(ModelState.IsValid)
            {
                Message message = new Message { MessageText = model.Message, From = model.From, To = model.To, MessageDate = model.MessDate };
                db.Messages.Add(message);
                await db.SaveChangesAsync();
                return new JsonResult(message);
            }
            return new JsonResult("Не корректные входящие данные");
        }

        [HttpPost]
        [Route("allMess")]
        public async Task<JsonResult> GetAllMess([FromBody] FromTo model)
        {
            var messall = await (from v in db.Messages
                           where v.From == model.From
                           where v.To == model.To
                           select v).ToListAsync();

            return new JsonResult(messall);
        }

    }
}
