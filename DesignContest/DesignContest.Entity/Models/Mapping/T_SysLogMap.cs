using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DesignContest.Entity.Models.Mapping
{
    public class T_SysLogMap : EntityTypeConfiguration<T_SysLog>
    {
        public T_SysLogMap()
        {
            // Primary Key
            this.HasKey(t => t.F_GUID);

            // Properties
            this.Property(t => t.F_GUID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_LogType)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_LogTitle)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_LogContent)
                .IsRequired()
                .HasMaxLength(1000);

            this.Property(t => t.F_LogRemark)
                .HasMaxLength(500);

            this.Property(t => t.F_LogLevel)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_Text1)
                .HasMaxLength(500);

            this.Property(t => t.F_Text2)
                .HasMaxLength(500);

            this.Property(t => t.F_Text3)
                .HasMaxLength(500);

            this.Property(t => t.F_Text4)
                .HasMaxLength(500);

            this.Property(t => t.F_Text5)
                .HasMaxLength(500);

            this.Property(t => t.F_LastModifier)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_SysLog");
            this.Property(t => t.F_GUID).HasColumnName("F_GUID");
            this.Property(t => t.F_LogType).HasColumnName("F_LogType");
            this.Property(t => t.F_LogTitle).HasColumnName("F_LogTitle");
            this.Property(t => t.F_LogContent).HasColumnName("F_LogContent");
            this.Property(t => t.F_LogCreateDateTime).HasColumnName("F_LogCreateDateTime");
            this.Property(t => t.F_LogRemark).HasColumnName("F_LogRemark");
            this.Property(t => t.F_LogLevel).HasColumnName("F_LogLevel");
            this.Property(t => t.F_Text1).HasColumnName("F_Text1");
            this.Property(t => t.F_Text2).HasColumnName("F_Text2");
            this.Property(t => t.F_Text3).HasColumnName("F_Text3");
            this.Property(t => t.F_Text4).HasColumnName("F_Text4");
            this.Property(t => t.F_Text5).HasColumnName("F_Text5");
            this.Property(t => t.F_LastModifier).HasColumnName("F_LastModifier");
            this.Property(t => t.F_LastModifyDate).HasColumnName("F_LastModifyDate");
        }
    }
}
