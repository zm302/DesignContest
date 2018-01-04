using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DesignContest.Entity.Models.Mapping
{
    public class T_LogMap : EntityTypeConfiguration<T_Log>
    {
        public T_LogMap()
        {
            // Primary Key
            this.HasKey(t => t.F_LogID);

            // Properties
            this.Property(t => t.F_LogID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_LogType)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_LogTitle)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.F_LogName)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.F_LogContent)
                .IsRequired();

            this.Property(t => t.F_LogRemark)
                .HasMaxLength(500);

            this.Property(t => t.F_Remark)
                .HasMaxLength(500);

            this.Property(t => t.F_Text1)
                .HasMaxLength(500);

            this.Property(t => t.F_Text2)
                .HasMaxLength(500);

            this.Property(t => t.F_Text3)
                .HasMaxLength(500);

            this.Property(t => t.F_Text4)
                .HasMaxLength(500);

            this.Property(t => t.F_LastModifier)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_Log");
            this.Property(t => t.F_LogID).HasColumnName("F_LogID");
            this.Property(t => t.F_LogType).HasColumnName("F_LogType");
            this.Property(t => t.F_LogTitle).HasColumnName("F_LogTitle");
            this.Property(t => t.F_LogName).HasColumnName("F_LogName");
            this.Property(t => t.F_LogContent).HasColumnName("F_LogContent");
            this.Property(t => t.F_LogDate).HasColumnName("F_LogDate");
            this.Property(t => t.F_LogRemark).HasColumnName("F_LogRemark");
            this.Property(t => t.F_Remark).HasColumnName("F_Remark");
            this.Property(t => t.F_Text1).HasColumnName("F_Text1");
            this.Property(t => t.F_Text2).HasColumnName("F_Text2");
            this.Property(t => t.F_Text3).HasColumnName("F_Text3");
            this.Property(t => t.F_Text4).HasColumnName("F_Text4");
            this.Property(t => t.F_LastModifier).HasColumnName("F_LastModifier");
            this.Property(t => t.F_LastModifyDate).HasColumnName("F_LastModifyDate");
        }
    }
}
