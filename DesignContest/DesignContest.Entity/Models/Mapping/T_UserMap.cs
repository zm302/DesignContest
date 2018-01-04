using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DesignContest.Entity.Models.Mapping
{
    public class T_UserMap : EntityTypeConfiguration<T_User>
    {
        public T_UserMap()
        {
            // Primary Key
            this.HasKey(t => t.F_UserName);

            // Properties
            this.Property(t => t.F_UserID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_UserName)
                .IsRequired()
                .HasMaxLength(12);

            this.Property(t => t.F_ShowName)
                .HasMaxLength(50);

            this.Property(t => t.F_PassWord)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_RoleID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_HeadPictureURL)
                .HasMaxLength(100);

            this.Property(t => t.F_Mobile)
                .HasMaxLength(11);

            this.Property(t => t.F_Email)
                .HasMaxLength(50);

            this.Property(t => t.F_Remark)
                .HasMaxLength(500);

            this.Property(t => t.F_LastLoginIP)
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
            this.ToTable("T_User");
            this.Property(t => t.F_UserID).HasColumnName("F_UserID");
            this.Property(t => t.F_UserName).HasColumnName("F_UserName");
            this.Property(t => t.F_ShowName).HasColumnName("F_ShowName");
            this.Property(t => t.F_PassWord).HasColumnName("F_PassWord");
            this.Property(t => t.F_RoleID).HasColumnName("F_RoleID");
            this.Property(t => t.F_Gender).HasColumnName("F_Gender");
            this.Property(t => t.F_Brithday).HasColumnName("F_Brithday");
            this.Property(t => t.F_IsDelete).HasColumnName("F_IsDelete");
            this.Property(t => t.F_HeadPictureURL).HasColumnName("F_HeadPictureURL");
            this.Property(t => t.F_Mobile).HasColumnName("F_Mobile");
            this.Property(t => t.F_Email).HasColumnName("F_Email");
            this.Property(t => t.F_Remark).HasColumnName("F_Remark");
            this.Property(t => t.F_LastLoginDatetime).HasColumnName("F_LastLoginDatetime");
            this.Property(t => t.F_LastLoginIP).HasColumnName("F_LastLoginIP");
            this.Property(t => t.F_Text1).HasColumnName("F_Text1");
            this.Property(t => t.F_Text2).HasColumnName("F_Text2");
            this.Property(t => t.F_Text3).HasColumnName("F_Text3");
            this.Property(t => t.F_Text4).HasColumnName("F_Text4");
            this.Property(t => t.F_Text5).HasColumnName("F_Text5");
            this.Property(t => t.F_LastModifier).HasColumnName("F_LastModifier");
            this.Property(t => t.F_ModfiyDate).HasColumnName("F_ModfiyDate");
        }
    }
}
