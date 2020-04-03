using MeuPortfolio.PortfolioManagement.Infra.SQL.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace MeuPortfolio.PortfolioManagement.Api.Controllers
{
    public class BaseController : Controller
    {
        private readonly TenantContext _context;

        protected BaseController() { }
        
        protected BaseController(TenantContext context) 
        {
            _context = context;
        }
    }
}
