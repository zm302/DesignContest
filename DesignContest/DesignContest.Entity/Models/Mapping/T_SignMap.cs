using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DesignContest.Entity.Models.Mapping
{
    public class T_SignMap : EntityTypeConfiguration<T_Sign>
    {
        public T_SignMap()
        {
            // Primary Key
            this.HasKey(t => t.F_GUID);

            // Properties
            this.Property(t => t.F_GUID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_UserID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_SignType)
                .IsRequired()
                .HasMaxLength(50);

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

            this.Property(t => t.F_Text5)
                .HasMaxLength(500);

            this.Property(t => t.F_LastModifier)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_Sign");
            this.Property(t => t.F_GUID).HasColumnName("F_GUID");
            this.Property(t => t.F_UserID).HasColumnName("F_UserID");
            this.Property(t => t.F_SignTime).HasColumnName("F_SignTime");
            this.Property(t => t.F_SignType).HasColumnName("F_SignType");
            this.Property(t => t.F_Remark).HasColumnName("F_Remark");
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
