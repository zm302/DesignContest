using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DesignContest.Entity.Models.Mapping
{
    public class T_DevicesMap : EntityTypeConfiguration<T_Devices>
    {
        public T_DevicesMap()
        {
            // Primary Key
            this.HasKey(t => t.F_DeviceID);

            // Properties
            this.Property(t => t.F_DeviceID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_DeviceTypeID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_DeviceName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_DeviceLocationID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_DeviceDescription)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.F_DeviceStatus)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_DeviceStatusCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_Remark)
                .IsRequired()
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
            this.ToTable("T_Devices");
            this.Property(t => t.F_DeviceID).HasColumnName("F_DeviceID");
            this.Property(t => t.F_DeviceTypeID).HasColumnName("F_DeviceTypeID");
            this.Property(t => t.F_DeviceName).HasColumnName("F_DeviceName");
            this.Property(t => t.F_DeviceLocationID).HasColumnName("F_DeviceLocationID");
            this.Property(t => t.F_DeviceDescription).HasColumnName("F_DeviceDescription");
            this.Property(t => t.F_IsDelete).HasColumnName("F_IsDelete");
            this.Property(t => t.F_DeviceStatus).HasColumnName("F_DeviceStatus");
            this.Property(t => t.F_DeviceStatusCode).HasColumnName("F_DeviceStatusCode");
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
