namespace EMS.DataProvider.Models.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    /// <summary>
    /// 有定制属性，不能直接用EF生成的实体代码覆盖
    /// </summary>
    public partial class Common_SiteMap_Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Common_SiteMap_Menu()
        {
            ChildrenMenu = new HashSet<Common_SiteMap_Menu>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MenuID { get; set; }

        public int? ParentID { get; set; }

        [Required]
        [StringLength(100)]
        public string ResourceKey { get; set; }

        [StringLength(100)]
        public string Area { get; set; }

        [StringLength(100)]
        public string Controller { get; set; }

        [StringLength(100)]
        public string ActionName { get; set; }

        [StringLength(500)]
        public string RouteValues { get; set; }

        public bool IsSkip { get; set; }

        public int DisplayOrder { get; set; }

        public bool? IsShow { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Common_SiteMap_Menu> Common_SiteMap_Menu1 { get; set; }
        public virtual ICollection<Common_SiteMap_Menu> ChildrenMenu { get; set; }

        //public virtual Common_SiteMap_Menu Common_SiteMap_Menu2 { get; set; }
        public virtual Common_SiteMap_Menu ParentMenu { get; set; }
    }
}
