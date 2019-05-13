namespace EMS.DataProvider.Models.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    public partial class Common_Authen_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Common_Authen_User()
        {
            Common_Authen_RoleUser = new HashSet<Common_Authen_RoleUser>();
        }

        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(20)]
        public string LogonName { get; set; }

        [Required]
        [StringLength(16)]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(30)]
        public string EmailAddress { get; set; }

        [StringLength(18)]
        public string IDNumber { get; set; }

        public DateTime? DateOFBirth { get; set; }

        public int Status { get; set; }

        public bool? CanDelete { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Common_Authen_RoleUser> Common_Authen_RoleUser { get; set; }
    }
}
