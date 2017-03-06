namespace Nik.Advanced.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sys_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sys_User()
        {
            Sys_UserMenuMapping = new HashSet<Sys_UserMenuMapping>();
        }

        public int Id { get; set; }

        [StringLength(32)]
        public string NameFirst { get; set; }

        [StringLength(32)]
        public string Name { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(128)]
        public string Address { get; set; }

        [StringLength(16)]
        public string QQ { get; set; }

        [MaxLength(32)]
        public byte[] Wechat { get; set; }

        public int? CompanyId { get; set; }

        [StringLength(32)]
        public string CompanyName { get; set; }

        public virtual Sys_Company Sys_Company { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sys_UserMenuMapping> Sys_UserMenuMapping { get; set; }
    }
}
