namespace Nik.Advanced.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sys_Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sys_Menu()
        {
            Sys_UserMenuMapping = new HashSet<Sys_UserMenuMapping>();
        }

        public int Id { get; set; }

        [StringLength(8)]
        public string Code { get; set; }

        [StringLength(32)]
        public string Name { get; set; }

        public int? ParentId { get; set; }

        public int? Level { get; set; }

        [StringLength(64)]
        public string Path { get; set; }

        public int? Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sys_UserMenuMapping> Sys_UserMenuMapping { get; set; }
    }
}
