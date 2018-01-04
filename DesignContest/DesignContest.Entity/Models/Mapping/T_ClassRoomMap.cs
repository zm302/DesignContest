using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DesignContest.Entity.Models.Mapping
{
    public class T_ClassRoomMap : EntityTypeConfiguration<T_ClassRoom>
    {
        public T_ClassRoomMap()
        {
            // Primary Key
            this.HasKey(t => t.F_ClassRoomID);

            // Properties
            this.Property(t => t.F_ClassRoomID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_ClassRoomName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_ClassTypeCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_ClassFunction)
                .HasMaxLength(50);

            this.Property(t => t.F_ClassRoomLocation)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_ClassDescription)
                .HasMaxLength(500);

            this.Property(t => t.F_ClassRoomRemark)
                .HasMaxLength(500);

            this.Property(t => t.F_Remark)
                .HasMaxLength(200);

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
            this.ToTable("T_ClassRoom");
            this.Property(t => t.F_ClassRoomID).HasColumnName("F_ClassRoomID");
            this.Property(t => t.F_ClassRoomName).HasColumnName("F_ClassRoomName");
            this.Property(t => t.F_ClassTypeCode).HasColumnName("F_ClassTypeCode");
            this.Property(t => t.F_ClassFunction).HasColumnName("F_ClassFunction");
            this.Property(t => t.F_IsDelete).HasColumnName("F_IsDelete");
            this.Property(t => t.F_ClassRoomLocation).HasColumnName("F_ClassRoomLocation");
            this.Property(t => t.F_ClassDescription).HasColumnName("F_ClassDescription");
            this.Property(t => t.F_ClassRoomRemark).HasColumnName("F_ClassRoomRemark");
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
