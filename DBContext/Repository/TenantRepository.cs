using Domain.Entity;
using MeuPortfolio.PortfolioManagement.Infra.SQL.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DBContext.Repository
{
    public class TenantRepository
    {
        private readonly TenantContext _context;

        public TenantRepository(TenantContext context)
        {
            _context = context;
        }

        public Tenant[] GetTenants()
        {
            return _context
                .Tenants
                .AsNoTracking()
                .ToArray();
        }
    }
}
