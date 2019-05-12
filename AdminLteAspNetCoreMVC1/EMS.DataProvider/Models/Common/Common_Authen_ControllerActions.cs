namespace EMS.DataProvider.Models.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Common_Authen_ControllerActions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int PermissionLevelID { get; set; }

        [StringLength(100)]
        public string Area { get; set; }

        [Required]
        [StringLength(100)]
        public string Controller { get; set; }

        [Required]
        [StringLength(100)]
        public string ActionName { get; set; }

        public bool HasActionPermission { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public virtual Common_Authen_FunctionPermissionLevel Common_Authen_FunctionPermissionLevel { get; set; }
    }
}
