using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;

namespace HRIS.Data.Entity
{
    internal class mf_EmploymentStatuConfiguration : EntityTypeConfiguration<mf_EmploymentStatu>
    {
        public mf_EmploymentStatuConfiguration()
            : this("dbo")
        {
        }

        public mf_EmploymentStatuConfiguration(string schema)
        {
            ToTable(schema + ".mf_EmploymentStatus");
            HasKey(x => x.id);

            Property(x => x.id).HasColumnName("id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.code).HasColumnName("code").IsRequired().HasMaxLength(50);
            Property(x => x.description).HasColumnName("description").IsRequired().HasMaxLength(250);
            Property(x => x.allowProcessPayroll).HasColumnName("allowProcessPayroll").IsRequired();
            Property(x => x.updatedBy).HasColumnName("updatedBy").IsRequired();
            Property(x => x.updatedDate).HasColumnName("updatedDate").IsRequired().HasColumnType("datetime");
            Property(x => x.deleted).HasColumnName("deleted").IsRequired();

            HasRequired(a => a.sys_User).WithMany(b => b.mf_EmploymentStatus).HasForeignKey(c => c.updatedBy);
        }
    }
}