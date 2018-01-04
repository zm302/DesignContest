using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DesignContest.Entity.Models.Mapping
{
    public class T_StaffRecordMap : EntityTypeConfiguration<T_StaffRecord>
    {
        public T_StaffRecordMap()
        {
            // Primary Key
            this.HasKey(t => t.F_staffRecordID);

            // Properties
            this.Property(t => t.F_staffID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_recordNote)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_StaffRecord");
            this.Property(t => t.F_staffRecordID).HasColumnName("F_staffRecordID");
            this.Property(t => t.F_staffID).HasColumnName("F_staffID");
            this.Property(t => t.F_signCount).HasColumnName("F_signCount");
            this.Property(t => t.F_recordNote).HasColumnName("F_recordNote");
        }
    }
}
