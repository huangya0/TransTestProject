using EMS.DataProvider.Contexts;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLteAspNetCoreMVC1.Common
{
    public class BaseController : Controller
    {
        protected readonly EmsWebDB _emsWebDB;

        public BaseController()
        {
            //IWebHost host = Program.host; //Program.BuildWebHost(null);
            //IServiceScope scope = host.Services.CreateScope();
            //_emsWebDB = scope.ServiceProvider.GetService<EmsWebDB>();

            //var list = _emsWebDB.vw_Authen_RolePermissions.ToList();
        }
    }
}
