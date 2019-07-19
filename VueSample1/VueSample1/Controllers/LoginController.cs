using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace VueSample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet("Login/{userName}/{pwd}")]
        [EnableCors("CorsSample")]
        public ActionResult<string> Login(string userName, string pwd)
        {
            return $"{userName}+{pwd} logon!";
            //string s = $"服务器{{{userName}:{pwd}}}";
        }
    }
}
