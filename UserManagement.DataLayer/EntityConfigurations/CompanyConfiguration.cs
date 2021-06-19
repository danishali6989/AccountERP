using UserManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserManagement.DataLayer.EntityConfigurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companys");

            builder.HasKey(x => x.CompanyId);

            builder.Property(x => x.CompanyId).ValueGeneratedOnAdd();

            builder.Property(x => x.CompanyName).IsRequired().HasMaxLength(500);
        }
    }
}
