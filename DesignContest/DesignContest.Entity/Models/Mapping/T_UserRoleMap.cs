using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DesignContest.Entity.Models.Mapping
{
    public class T_UserRoleMap : EntityTypeConfiguration<T_UserRole>
    {
        public T_UserRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.F_GUID);

            // Properties
            this.Property(t => t.F_GUID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_RoleID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_UserID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_LastModifier)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_UserRole");
            this.Property(t => t.F_GUID).HasColumnName("F_GUID");
            this.Property(t => t.F_RoleID).HasColumnName("F_RoleID");
            this.Property(t => t.F_UserID).HasColumnName("F_UserID");
            this.Property(t => t.F_LastModifier).HasColumnName("F_LastModifier");
            this.Property(t => t.F_LastModifyDate).HasColumnName("F_LastModifyDate");
        }
    }
}
