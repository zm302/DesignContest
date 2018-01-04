using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DesignContest.Entity.Models.Mapping
{
    public class T_LoginCertificateMap : EntityTypeConfiguration<T_LoginCertificate>
    {
        public T_LoginCertificateMap()
        {
            // Primary Key
            this.HasKey(t => t.F_UserID);

            // Properties
            this.Property(t => t.F_UserID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_Token)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_Remark)
                .HasMaxLength(500);

            this.Property(t => t.F_Text1)
                .HasMaxLength(50);

            this.Property(t => t.F_Text2)
                .HasMaxLength(50);

            this.Property(t => t.F_Text3)
                .HasMaxLength(50);

            this.Property(t => t.F_Text4)
                .HasMaxLength(50);

            this.Property(t => t.F_Text5)
                .HasMaxLength(50);

            this.Property(t => t.F_LastModifier)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_LoginCertificate");
            this.Property(t => t.F_UserID).HasColumnName("F_UserID");
            this.Property(t => t.F_Token).HasColumnName("F_Token");
            this.Property(t => t.F_CreateTime).HasColumnName("F_CreateTime");
            this.Property(t => t.F_LastOperateTime).HasColumnName("F_LastOperateTime");
            this.Property(t => t.F_TokenExpiryDate).HasColumnName("F_TokenExpiryDate");
            this.Property(t => t.F_Remark).HasColumnName("F_Remark");
            this.Property(t => t.F_Text1).HasColumnName("F_Text1");
            this.Property(t => t.F_Text2).HasColumnName("F_Text2");
            this.Property(t => t.F_Text3).HasColumnName("F_Text3");
            this.Property(t => t.F_Text4).HasColumnName("F_Text4");
            this.Property(t => t.F_Text5).HasColumnName("F_Text5");
            this.Property(t => t.F_LastModifier).HasColumnName("F_LastModifier");
            this.Property(t => t.F_LastModifyTime).HasColumnName("F_LastModifyTime");
        }
    }
}
