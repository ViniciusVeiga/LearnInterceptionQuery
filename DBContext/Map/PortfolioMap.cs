using DBContext.Map;
using Domain.Entity;
using Domain.Provider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MeuPortfolio.PortfolioManagement.Infra.SQL.DataContext.Maps
{
    public class PortfolioMap : IEntityTypeConfiguration<Portfolio>
    {
        private readonly TenantContext _context;

        public PortfolioMap(TenantContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.HasKey(e => e.Id);

            builder
                .HasOne(e => e.Tenant)
                .WithMany(e => e.Portfolios)
                .HasForeignKey(e => e.TenantId);

            builder.HasQueryFilter(e => e.TenantId == _context.TenantProvider.GetTenantId());

            builder.ToTable("Portfolios");
        }
    }
}
