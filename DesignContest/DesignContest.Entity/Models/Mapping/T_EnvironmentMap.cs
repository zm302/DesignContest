using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DesignContest.Entity.Models.Mapping
{
    public class T_EnvironmentMap : EntityTypeConfiguration<T_Environment>
    {
        public T_EnvironmentMap()
        {
            // Primary Key
            this.HasKey(t => t.F_GUID);

            // Properties
            this.Property(t => t.F_GUID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_SensorID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_DataType)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_SensorType)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_DataValue)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_ClassRoomID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_DataRemark)
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

            this.Property(t => t.F_Text5)
                .HasMaxLength(500);

            this.Property(t => t.F_LastModifier)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_Environment");
            this.Property(t => t.F_GUID).HasColumnName("F_GUID");
            this.Property(t => t.F_SensorID).HasColumnName("F_SensorID");
            this.Property(t => t.F_DataType).HasColumnName("F_DataType");
            this.Property(t => t.F_SensorType).HasColumnName("F_SensorType");
            this.Property(t => t.F_DataValue).HasColumnName("F_DataValue");
            this.Property(t => t.F_DataDate).HasColumnName("F_DataDate");
            this.Property(t => t.F_ClassRoomID).HasColumnName("F_ClassRoomID");
            this.Property(t => t.F_DataRemark).HasColumnName("F_DataRemark");
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
