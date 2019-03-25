namespace EMS.DataProvider.Models.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Common_Authen_Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Common_Authen_Role()
        {
            Common_Authen_RoleFunctionPermission = new HashSet<Common_Authen_RoleFunctionPermission>();
            Common_Authen_RoleUser = new HashSet<Common_Authen_RoleUser>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleID { get; set; }

        [Required]
        [StringLength(20)]
        public string RoleName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public bool? ShowFlag { get; set; }

        [StringLength(100)]
        public string ResourceKey { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Common_Authen_RoleFunctionPermission> Common_Authen_RoleFunctionPermission { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Common_Authen_RoleUser> Common_Authen_RoleUser { get; set; }
    }
}
