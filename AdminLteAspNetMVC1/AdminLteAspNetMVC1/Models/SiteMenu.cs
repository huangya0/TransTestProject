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

        private List<SiteMenu> childrenMenu;
        public virtual List<SiteMenu> ChildrenMenu
        {
            get
            {
                if (childrenMenu == null)
                {
                    return new List<SiteMenu>();
                }
                else
                {
                    return this.childrenMenu;
                }
            }
            set
            {
                childrenMenu = value;
            }
        }
        public virtual SiteMenu ParentMenu { get; set; } //应该没有用
    }
}
