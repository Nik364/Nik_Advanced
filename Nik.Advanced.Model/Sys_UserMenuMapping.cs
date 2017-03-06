namespace Nik.Advanced.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sys_UserMenuMapping
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? MenuId { get; set; }

        public virtual Sys_Menu Sys_Menu { get; set; }

        public virtual Sys_User Sys_User { get; set; }
    }
}
