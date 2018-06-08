using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NebulasAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Sakura.AspNetCore.Mvc;

namespace NebulasAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        public MyDbContext MyDbContext { get; }

        /// <summary>
        /// 建立数据库连接 构造方法
        /// </summary>
        /// <param name="DbContext"></param>
        public AccountController(MyDbContext DbContext)
        {
            MyDbContext = DbContext;
        }
        [HttpPost("regist")]
        public async Task<IActionResult> Regist([FromBody]Account newAccount)
        {
            try
            {
                var accounts = MyDbContext.Accounts;
                await accounts.AddAsync(newAccount);
                await MyDbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                throw new ActionResultException(HttpStatusCode.BadRequest, "bad info");
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]Account account)
        {

            var name = account.name;
            var password = account.password;
            var accounts = MyDbContext.Accounts;
            var ac = await (from i in accounts where name == i.name select i).FirstOrDefaultAsync();
            if (ac != null)
            {
                if (ac.password == password)
                {
                    return Ok();
                }
                else
                {
                    throw new ActionResultException(HttpStatusCode.Unauthorized, "password is not correct");
                }
            }
            else
            {
                throw new ActionResultException(HttpStatusCode.Unauthorized, "nouser");
            }


        }
    }
}
