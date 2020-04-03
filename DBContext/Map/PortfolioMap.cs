using DBContext.Map;
using Domain.Entity;
using Domain.Provider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuPortfolio.PortfolioManagement.Infra.SQL.DataContext.Maps
{
    public class PortfolioMap : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.HasKey(e => e.Id);

            builder
                .HasOne(e => e.Tenant)
                .WithMany(e => e.Portfolios)
                .HasForeignKey(e => e.TenantId);

            builder.ToTable("Portfolios");
        }
    }
}
