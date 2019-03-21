using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLteAspNetMVC1.ViewModel
{
    public class SiteMenu
    {
        public int MenuID { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string ResourceKey { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string ActionName { get; set; }
        public string RouteValues { get; set; }
        public bool IsSkip { get; set; }
        public int DisplayOrder { get; set; }
        public virtual List<SiteMenu> ChildrenMenu { get; set; }
        public virtual SiteMenu ParentMenu { get; set; } //应该没有用
    }
}
