using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DesignContest.Entity.Models.Mapping
{
    public class T_DictionaryMap : EntityTypeConfiguration<T_Dictionary>
    {
        public T_DictionaryMap()
        {
            // Primary Key
            this.HasKey(t => t.F_GUID);

            // Properties
            this.Property(t => t.F_GUID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_KEY)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_VALUE)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_SimpleValue)
                .HasMaxLength(50);

            this.Property(t => t.F_Type)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.F_Remark)
                .HasMaxLength(500);

            this.Property(t => t.F_LastModifier)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_Dictionary");
            this.Property(t => t.F_GUID).HasColumnName("F_GUID");
            this.Property(t => t.F_KEY).HasColumnName("F_KEY");
            this.Property(t => t.F_VALUE).HasColumnName("F_VALUE");
            this.Property(t => t.F_SimpleValue).HasColumnName("F_SimpleValue");
            this.Property(t => t.F_IsDelete).HasColumnName("F_IsDelete");
            this.Property(t => t.F_Type).HasColumnName("F_Type");
            this.Property(t => t.F_Remark).HasColumnName("F_Remark");
            this.Property(t => t.F_LastModifier).HasColumnName("F_LastModifier");
            this.Property(t => t.F_LastModityDate).HasColumnName("F_LastModityDate");
        }
    }
}
