using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EMS.DataProvider.Contexts;
using EMS.Model.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdminLteAspNetCoreMVC1
{
    public class Startup
    {
        public const string Default_ConnectionName = "EmsWebDB";
        public string ConnectionString = string.Empty;

        public static bool IsApplicationStarted = false;

        public Startup(IConfiguration configuration)
        {
            IsApplicationStarted = false;

            Configuration = configuration;

            ConnectionString = Configuration.GetConnectionString(Default_ConnectionName);
            //SqlDependency.Start(ConnectionString);
            IsApplicationStarted = true;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //方法1 ---- https://www.jb51.net/article/98948.htm
            EmsWebDB.ConnectionString = ConnectionString; // Configuration.GetConnectionString(ConnectionString);
            //方法2--https://stackoverflow.com/questions/39083372/how-to-read-connection-string-in-net-core
            //DbContext只用在BL层,若UI层要用,用以下注入方式,再在BaseController中GetService
            //services.AddDbContext<EmsWebDB>(options => options.UseSqlServer(ConnectionString));
            //services.AddSingleton<EmsWebDB>(new EmsWebDB(可以用构造传connection string));

            //smtp读取--
            //services.Configure<SmtpConfig>(Configuration.GetSection("Smtp"));
            //Microsoft.Extensions.Options.IOptions<SmtpConfig> smtpConfig)
            Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions.Configure<SmtpConfig>(services, Configuration.GetSection("Smtp"));


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }

    }
}
