using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;

namespace HRIS.Data.Entity
{
    internal class sys_IdentificationDocumentConfiguration : EntityTypeConfiguration<sys_IdentificationDocument>
    {
        public sys_IdentificationDocumentConfiguration()
            : this("dbo")
        {
        }

        public sys_IdentificationDocumentConfiguration(string schema)
        {
            ToTable(schema + ".sys_IdentificationDocument");
            HasKey(x => x.id);

            Property(x => x.id).HasColumnName("id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.code).HasColumnName("code").IsRequired().HasMaxLength(50);
            Property(x => x.description).HasColumnName("description").IsRequired().HasMaxLength(250);
            Property(x => x.updatedBy).HasColumnName("updatedBy").IsRequired();
            Property(x => x.updatedDate).HasColumnName("updatedDate").IsRequired().HasColumnType("datetime");
            Property(x => x.deleted).HasColumnName("deleted").IsRequired();

            HasRequired(a => a.sys_User_updatedBy).WithMany(b => b.sys_IdentificationDocuments).HasForeignKey(c => c.updatedBy);
        }
    }
}