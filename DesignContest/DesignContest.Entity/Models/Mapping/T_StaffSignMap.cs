using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DesignContest.Entity.Models.Mapping
{
    public class T_StaffSignMap : EntityTypeConfiguration<T_StaffSign>
    {
        public T_StaffSignMap()
        {
            // Primary Key
            this.HasKey(t => t.F_StaffSignID);

            // Properties
            this.Property(t => t.F_StaffID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_StaffName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_ClassRoomID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_ClassRoomName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_StaffSign");
            this.Property(t => t.F_StaffSignID).HasColumnName("F_StaffSignID");
            this.Property(t => t.F_StaffID).HasColumnName("F_StaffID");
            this.Property(t => t.F_StaffName).HasColumnName("F_StaffName");
            this.Property(t => t.F_SignTime).HasColumnName("F_SignTime");
            this.Property(t => t.F_ClassRoomID).HasColumnName("F_ClassRoomID");
            this.Property(t => t.F_ClassRoomName).HasColumnName("F_ClassRoomName");
        }
    }
}
