using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DesignContest.Entity.Models.Mapping
{
    public class T_DevicesFixRecordMap : EntityTypeConfiguration<T_DevicesFixRecord>
    {
        public T_DevicesFixRecordMap()
        {
            // Primary Key
            this.HasKey(t => t.F_FixID);

            // Properties
            this.Property(t => t.F_FixID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_FixName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_FixerName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_FixerCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_FixedStatusCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_FixDeviceID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_FixReporter)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_FixCause)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.F_FixDetails)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.F_FixMaterial)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.F_FixImageURL)
                .HasMaxLength(50);

            this.Property(t => t.F_FixedImageURL)
                .HasMaxLength(50);

            this.Property(t => t.F_FixRemark)
                .IsRequired()
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
            this.ToTable("T_DevicesFixRecord");
            this.Property(t => t.F_FixID).HasColumnName("F_FixID");
            this.Property(t => t.F_FixName).HasColumnName("F_FixName");
            this.Property(t => t.F_FixerName).HasColumnName("F_FixerName");
            this.Property(t => t.F_FixerCode).HasColumnName("F_FixerCode");
            this.Property(t => t.F_FixedStatusCode).HasColumnName("F_FixedStatusCode");
            this.Property(t => t.F_FixDeviceID).HasColumnName("F_FixDeviceID");
            this.Property(t => t.F_FixReporter).HasColumnName("F_FixReporter");
            this.Property(t => t.F_FixCause).HasColumnName("F_FixCause");
            this.Property(t => t.F_FixDetails).HasColumnName("F_FixDetails");
            this.Property(t => t.F_FixMaterial).HasColumnName("F_FixMaterial");
            this.Property(t => t.F_FixImageURL).HasColumnName("F_FixImageURL");
            this.Property(t => t.F_FixedImageURL).HasColumnName("F_FixedImageURL");
            this.Property(t => t.F_FixCost).HasColumnName("F_FixCost");
            this.Property(t => t.F_FixRemark).HasColumnName("F_FixRemark");
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
