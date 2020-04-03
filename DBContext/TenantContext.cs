using DBContext.Extensions;
using Domain.Entity;
using Domain.Provider;
using MeuPortfolio.PortfolioManagement.Infra.SQL.DataContext.Maps;
using Microsoft.EntityFrameworkCore;
using System;

namespace MeuPortfolio.PortfolioManagement.Infra.SQL.DataContext
{
    public class TenantContext : DbContext
    {
        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<Portfolio> Portfolios { get; set; }

        public TenantProvider TenantProvider { get; private set; }

        public TenantContext(
            DbContextOptions<TenantContext> options,
            TenantProvider tenantProvider) : base(options)
        {
            TenantProvider = tenantProvider;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TenantMap());
            modelBuilder.ApplyConfiguration(new PortfolioMap());
        }

        public override int SaveChanges()
        {
            ChangeTracker.ProcessCreation(TenantProvider);

            return base.SaveChanges();
        }
    }
}
