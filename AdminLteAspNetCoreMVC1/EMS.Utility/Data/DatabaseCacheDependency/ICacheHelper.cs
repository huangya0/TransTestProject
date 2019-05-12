using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Utility.Data.DatabaseCacheDependency
{
    public interface ICacheHelper
    {
        string CacheId { get; }
        System.Collections.Generic.List<T> GetLinqCahce<T>(System.Linq.IQueryable<T> q);
    }
}
