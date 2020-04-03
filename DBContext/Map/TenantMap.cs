using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuPortfolio.PortfolioManagement.Infra.SQL.DataContext.Maps
{
    public class TenantMap : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasQueryFilter(e => e.IsActive);

            builder.ToTable("Tenants");
        }
    }
}
