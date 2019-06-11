using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdminLteAspNetCoreMVC1.Models;
using EMS.Model;
using EMS.BL;
using AdminLteAspNetCoreMVC1.Common;
using EMS.DataProvider.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;

namespace AdminLteAspNetCoreMVC1.Controllers
{
    public class HomeController : BaseController
    {
        //protected readonly EmsWebDB _emsWebDB;

        //public HomeController(EmsWebDB emsWebDB)
        //{
        //    //this.HttpContext.Request.Host
        //    IWebHost host = Program.host; //Program.BuildWebHost(null);
        //    IServiceScope scope = host.Services.CreateScope();
        //    var _dataContext = scope.ServiceProvider.GetService<EmsWebDB>();

        //    _emsWebDB = _dataContext;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            //SampleItemModel sampleItemModel = (new SampleBL()).GetSampleList().Where(i => i.Id == 3).First();
            SampleItemModel sampleItemModel = (new SampleBL()).GetSampleList().Where(i => i.Id == 3).First();
            if (sampleItemModel == null)
            {
                //return HttpNotFound();
            }
            return View(sampleItemModel);

            //return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
