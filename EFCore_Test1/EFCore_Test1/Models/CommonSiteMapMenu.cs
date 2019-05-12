using System;
using System.Collections.Generic;

namespace EFCore_Test1.Models
{
    public partial class CommonSiteMapMenu
    {
        public CommonSiteMapMenu()
        {
            InverseParent = new HashSet<CommonSiteMapMenu>();
        }

        public int MenuId { get; set; }
        public int? ParentId { get; set; }
        public string ResourceKey { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string ActionName { get; set; }
        public string RouteValues { get; set; }
        public bool IsSkip { get; set; }
        public int DisplayOrder { get; set; }
        public bool? IsShow { get; set; }

        public virtual CommonSiteMapMenu Parent { get; set; }
        public virtual ICollection<CommonSiteMapMenu> InverseParent { get; set; }
    }
}
