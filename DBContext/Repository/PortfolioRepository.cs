using Domain.Entity;
using MeuPortfolio.PortfolioManagement.Infra.SQL.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DBContext.Repository
{
    public class PortfolioRepository
    {
        private readonly TenantContext _context;

        public PortfolioRepository(TenantContext context)
        {
            _context = context;
        }

        public Portfolio[] GetPortfolios()
        {
            return _context
                .Portfolios
                .AsNoTracking()
                .Where(p => _context.TenantProvider.Id.Equals(p.TenantId))
                .ToArray();
        }

        public Portfolio GetPortfolio(Guid id)
        {
            return _context
                .Portfolios
                .AsNoTracking()
                .Where(p => _context.TenantProvider.Id.Equals(p.TenantId))
                .Where(p => id.Equals(p.Id))
                .FirstOrDefault();
        }

        public void Add(Portfolio portfolio)
        {
            _context.Add(portfolio);
            _context.SaveChanges();
        }
    }
}
