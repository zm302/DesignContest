using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DesignContest.Entity.Models.Mapping
{
    public class T_StaffMap : EntityTypeConfiguration<T_Staff>
    {
        public T_StaffMap()
        {
            // Primary Key
            this.HasKey(t => t.F_staffID);

            // Properties
            this.Property(t => t.F_staffID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_staffName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_sex)
                .HasMaxLength(2);

            this.Property(t => t.F_phone)
                .HasMaxLength(13);

            this.Property(t => t.F_address)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_Staff");
            this.Property(t => t.F_staffID).HasColumnName("F_staffID");
            this.Property(t => t.F_staffName).HasColumnName("F_staffName");
            this.Property(t => t.F_sex).HasColumnName("F_sex");
            this.Property(t => t.F_age).HasColumnName("F_age");
            this.Property(t => t.F_phone).HasColumnName("F_phone");
            this.Property(t => t.F_startWorkTime).HasColumnName("F_startWorkTime");
            this.Property(t => t.F_address).HasColumnName("F_address");
        }
    }
}
