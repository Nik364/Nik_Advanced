namespace Nik.Advanced.Model.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NikDbContext : DbContext
    {
        public NikDbContext()
            : base("name=NikDbContext")
        {
        }

        public virtual DbSet<Sys_Company> Company { get; set; }
        public virtual DbSet<Sys_Menu> Menu { get; set; }
        public virtual DbSet<Sys_User> User { get; set; }
        public virtual DbSet<Sys_UserMenuMapping> UserMenuMapping { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sys_Company>()
                .HasMany(e => e.Sys_User)
                .WithOptional(e => e.Sys_Company)
                .HasForeignKey(e => e.CompanyId);

            modelBuilder.Entity<Sys_Menu>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Sys_Menu>()
                .Property(e => e.Path)
                .IsUnicode(false);

            modelBuilder.Entity<Sys_Menu>()
                .HasMany(e => e.Sys_UserMenuMapping)
                .WithOptional(e => e.Sys_Menu)
                .HasForeignKey(e => e.MenuId);

            modelBuilder.Entity<Sys_User>()
                .Property(e => e.NameFirst)
                .IsUnicode(false);

            modelBuilder.Entity<Sys_User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Sys_User>()
                .Property(e => e.QQ)
                .IsUnicode(false);

            modelBuilder.Entity<Sys_User>()
                .HasMany(e => e.Sys_UserMenuMapping)
                .WithOptional(e => e.Sys_User)
                .HasForeignKey(e => e.UserId);
        }
    }
}
