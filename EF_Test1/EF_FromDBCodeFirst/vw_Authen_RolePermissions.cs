namespace EF_FromDBCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_Authen_RolePermissions
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string RoleName { get; set; }

        [StringLength(100)]
        public string Area { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string Controller { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string ActionName { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool HasActionPermission { get; set; }
    }
}
