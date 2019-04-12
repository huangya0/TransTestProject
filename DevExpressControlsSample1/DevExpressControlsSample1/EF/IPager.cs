using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpressControlsSample1.EF
{
    public interface IPager
    {
        int PageNum { get; set; }
        int PageSize { get; set; }
        int PagerItemCount { get; set; }
        int RecordCount { get; set; }
        int TotalPage { get; set; }
    }
}
