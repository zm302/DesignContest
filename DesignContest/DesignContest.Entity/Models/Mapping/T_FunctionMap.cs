using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DesignContest.Entity.Models.Mapping
{
    public class T_FunctionMap : EntityTypeConfiguration<T_Function>
    {
        public T_FunctionMap()
        {
            // Primary Key
            this.HasKey(t => t.F_FunctionID);

            // Properties
            this.Property(t => t.F_FunctionID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_FunctionName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_ParentID)
                .HasMaxLength(50);

            this.Property(t => t.F_PageUrl)
                .HasMaxLength(100);

            this.Property(t => t.F_DefaultUrl)
                .HasMaxLength(100);

            this.Property(t => t.F_Icon)
                .HasMaxLength(100);

            this.Property(t => t.F_ApplicationID)
                .HasMaxLength(50);

            this.Property(t => t.F_LastModifier)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_Function");
            this.Property(t => t.F_FunctionID).HasColumnName("F_FunctionID");
            this.Property(t => t.F_FunctionName).HasColumnName("F_FunctionName");
            this.Property(t => t.F_IsPage).HasColumnName("F_IsPage");
            this.Property(t => t.F_IsMenu).HasColumnName("F_IsMenu");
            this.Property(t => t.F_IsButton).HasColumnName("F_IsButton");
            this.Property(t => t.F_ParentID).HasColumnName("F_ParentID");
            this.Property(t => t.F_PageUrl).HasColumnName("F_PageUrl");
            this.Property(t => t.F_OrderNum).HasColumnName("F_OrderNum");
            this.Property(t => t.F_DefaultUrl).HasColumnName("F_DefaultUrl");
            this.Property(t => t.F_IsVisible).HasColumnName("F_IsVisible");
            this.Property(t => t.F_IsDelete).HasColumnName("F_IsDelete");
            this.Property(t => t.F_Icon).HasColumnName("F_Icon");
            this.Property(t => t.F_ApplicationID).HasColumnName("F_ApplicationID");
            this.Property(t => t.F_LastModifier).HasColumnName("F_LastModifier");
            this.Property(t => t.F_LastModifyDate).HasColumnName("F_LastModifyDate");
        }
    }
}
