using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DesignContest.Entity.Models.Mapping
{
    public class T_RoleFunctionMap : EntityTypeConfiguration<T_RoleFunction>
    {
        public T_RoleFunctionMap()
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

            this.Property(t => t.F_FunctionID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_LastModifier)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_RoleFunction");
            this.Property(t => t.F_GUID).HasColumnName("F_GUID");
            this.Property(t => t.F_RoleID).HasColumnName("F_RoleID");
            this.Property(t => t.F_FunctionID).HasColumnName("F_FunctionID");
            this.Property(t => t.F_LastModifier).HasColumnName("F_LastModifier");
            this.Property(t => t.F_LastModifyDate).HasColumnName("F_LastModifyDate");
        }
    }
}
