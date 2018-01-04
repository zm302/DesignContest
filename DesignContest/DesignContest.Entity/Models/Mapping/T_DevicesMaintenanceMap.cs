using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DesignContest.Entity.Models.Mapping
{
    public class T_DevicesMaintenanceMap : EntityTypeConfiguration<T_DevicesMaintenance>
    {
        public T_DevicesMaintenanceMap()
        {
            // Primary Key
            this.HasKey(t => t.F_GUID);

            // Properties
            this.Property(t => t.F_GUID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_DeviceID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_MaintenanceType)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_MaintenanceDetail)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.F_Maintenancer)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_MaintenanceRemark)
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
            this.ToTable("T_DevicesMaintenance");
            this.Property(t => t.F_GUID).HasColumnName("F_GUID");
            this.Property(t => t.F_DeviceID).HasColumnName("F_DeviceID");
            this.Property(t => t.F_MaintenanceType).HasColumnName("F_MaintenanceType");
            this.Property(t => t.F_MaintenanceDetail).HasColumnName("F_MaintenanceDetail");
            this.Property(t => t.F_MaintenanceDate).HasColumnName("F_MaintenanceDate");
            this.Property(t => t.F_Maintenancer).HasColumnName("F_Maintenancer");
            this.Property(t => t.F_MaintenanceRemark).HasColumnName("F_MaintenanceRemark");
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
