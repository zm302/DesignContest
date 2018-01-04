using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DesignContest.Entity.Models.Mapping
{
    public class T_NoticeMap : EntityTypeConfiguration<T_Notice>
    {
        public T_NoticeMap()
        {
            // Primary Key
            this.HasKey(t => t.F_GUID);

            // Properties
            this.Property(t => t.F_GUID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_NoticeID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_NotiveType)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_NoticeTitle)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.F_NoticeText)
                .IsRequired()
                .HasMaxLength(1000);

            this.Property(t => t.F_NoticeRemark)
                .HasMaxLength(1000);

            this.Property(t => t.F_NoticeCreater)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_NoticeCreaterIP)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_Reviewer)
                .HasMaxLength(50);

            this.Property(t => t.F_NoticeState)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_AttachUrl)
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

            this.Property(t => t.F_LastModify)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_Notice");
            this.Property(t => t.F_GUID).HasColumnName("F_GUID");
            this.Property(t => t.F_NoticeID).HasColumnName("F_NoticeID");
            this.Property(t => t.F_NotiveType).HasColumnName("F_NotiveType");
            this.Property(t => t.F_NoticeTitle).HasColumnName("F_NoticeTitle");
            this.Property(t => t.F_NoticeText).HasColumnName("F_NoticeText");
            this.Property(t => t.F_NoticeRemark).HasColumnName("F_NoticeRemark");
            this.Property(t => t.F_NoticeCreater).HasColumnName("F_NoticeCreater");
            this.Property(t => t.F_NoticeDateTime).HasColumnName("F_NoticeDateTime");
            this.Property(t => t.F_NoticeTermOfValidity).HasColumnName("F_NoticeTermOfValidity");
            this.Property(t => t.F_NoticeCreaterIP).HasColumnName("F_NoticeCreaterIP");
            this.Property(t => t.F_IsDelete).HasColumnName("F_IsDelete");
            this.Property(t => t.F_IsVisible).HasColumnName("F_IsVisible");
            this.Property(t => t.F_IsReviewed).HasColumnName("F_IsReviewed");
            this.Property(t => t.F_Reviewer).HasColumnName("F_Reviewer");
            this.Property(t => t.F_NoticeState).HasColumnName("F_NoticeState");
            this.Property(t => t.F_IsAttached).HasColumnName("F_IsAttached");
            this.Property(t => t.F_AttachUrl).HasColumnName("F_AttachUrl");
            this.Property(t => t.F_AttachTermOfValidity).HasColumnName("F_AttachTermOfValidity");
            this.Property(t => t.F_Text1).HasColumnName("F_Text1");
            this.Property(t => t.F_Text2).HasColumnName("F_Text2");
            this.Property(t => t.F_Text3).HasColumnName("F_Text3");
            this.Property(t => t.F_Text4).HasColumnName("F_Text4");
            this.Property(t => t.F_Text5).HasColumnName("F_Text5");
            this.Property(t => t.F_LastModify).HasColumnName("F_LastModify");
            this.Property(t => t.F_LastModifyDate).HasColumnName("F_LastModifyDate");
        }
    }
}
