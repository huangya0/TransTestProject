using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataProvider.Common
{
    public partial class BaseContext : DbContext
    {
        //public BaseContext()
        //    : base("Name=EmsWebDB")
        //{

        //}

        //public BaseContext(string nameOrConnectionString)
        //    : base(nameOrConnectionString)
        //{
        //    Database.CommandTimeout = 60;
        //}

        public BaseContext(DbContextOptions<BaseContext> options)
            : base(options)
        {
            Database.SetCommandTimeout(60);
        }
    }
}
