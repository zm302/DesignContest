using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DesignContest.Entity.Models.Mapping
{
    public class T_RoleMap : EntityTypeConfiguration<T_Role>
    {
        public T_RoleMap()
        {
            // Primary Key
            this.HasKey(t => t.F_RoleID);

            // Properties
            this.Property(t => t.F_RoleID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_RoleName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_Description)
                .HasMaxLength(500);

            this.Property(t => t.F_Text01)
                .HasMaxLength(500);

            this.Property(t => t.F_Text02)
                .HasMaxLength(500);

            this.Property(t => t.F_Text03)
                .HasMaxLength(500);

            this.Property(t => t.F_Text04)
                .HasMaxLength(500);

            this.Property(t => t.F_Text05)
                .HasMaxLength(500);

            this.Property(t => t.F_LastModifier)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_Role");
            this.Property(t => t.F_RoleID).HasColumnName("F_RoleID");
            this.Property(t => t.F_RoleName).HasColumnName("F_RoleName");
            this.Property(t => t.F_Description).HasColumnName("F_Description");
            this.Property(t => t.F_IsDelete).HasColumnName("F_IsDelete");
            this.Property(t => t.F_Text01).HasColumnName("F_Text01");
            this.Property(t => t.F_Text02).HasColumnName("F_Text02");
            this.Property(t => t.F_Text03).HasColumnName("F_Text03");
            this.Property(t => t.F_Text04).HasColumnName("F_Text04");
            this.Property(t => t.F_Text05).HasColumnName("F_Text05");
            this.Property(t => t.F_LastModifier).HasColumnName("F_LastModifier");
            this.Property(t => t.F_LastModifyDate).HasColumnName("F_LastModifyDate");
        }
    }
}
