namespace EMS.DataProvider.Models.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    public partial class Common_Authen_FunctionPermissionLevel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Common_Authen_FunctionPermissionLevel()
        {
            Common_Authen_ControllerActions = new HashSet<Common_Authen_ControllerActions>();
            Common_Authen_RoleFunctionPermission = new HashSet<Common_Authen_RoleFunctionPermission>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string FunctionName { get; set; }

        [Required]
        [StringLength(50)]
        public string PermissionLevel { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Common_Authen_ControllerActions> Common_Authen_ControllerActions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Common_Authen_RoleFunctionPermission> Common_Authen_RoleFunctionPermission { get; set; }
    }
}
