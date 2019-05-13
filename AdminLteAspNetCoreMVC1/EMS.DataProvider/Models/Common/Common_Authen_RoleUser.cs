namespace EMS.DataProvider.Models.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Common_Authen_RoleUser
    {
        public int ID { get; set; }

        public int RoleID { get; set; }

        public int UserID { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public virtual Common_Authen_Role Common_Authen_Role { get; set; }

        public virtual Common_Authen_User Common_Authen_User { get; set; }
    }
}
