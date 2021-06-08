using AccountErp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountErp.DataLayer.EntityConfigurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companys");

            builder.HasKey(x => x.CompanyTenantId);

            builder.Property(x => x.CompanyTenantId).ValueGeneratedOnAdd();

            builder.Property(x => x.CompanyName).IsRequired().HasMaxLength(500);
        }
    }
}
