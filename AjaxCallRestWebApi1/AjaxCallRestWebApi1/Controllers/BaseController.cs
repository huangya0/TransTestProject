using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AjaxCallRestWebApi1.Util;

namespace AjaxCallRestWebApi1.Controllers
{
    [RequestAuthorize]
    public class BaseController : ApiController
    {
    }
}