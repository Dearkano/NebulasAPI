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
    }
}
