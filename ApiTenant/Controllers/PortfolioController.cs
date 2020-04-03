using DBContext.Repository;
using Domain.Entity;
using Domain.ViewModel;
using MeuPortfolio.PortfolioManagement.Api.Controllers;
using MeuPortfolio.PortfolioManagement.Infra.SQL.DataContext;
using Microsoft.AspNetCore.Mvc;

namespace ApiTenant.Controllers
{
    [ApiController]
    public class PortfolioController : BaseController
    {
        private readonly PortfolioRepository _portfolioRepository;

        public PortfolioController(
            PortfolioRepository portfolioRepository,
            TenantContext context) : base(context)
        {
            _portfolioRepository = portfolioRepository;
        }

        [HttpGet]
        [Route("/portfolios")]
        public IActionResult Get()
        {
            return Ok(_portfolioRepository.GetPortfolios());
        }

        [HttpPost]
        [Route("/portfolios")]
        public IActionResult Post([FromBody]PortfolioViewModel model)
        {
            var portfolio = new Portfolio(model.Name);

            _portfolioRepository.Add(portfolio);
            return Ok(_portfolioRepository.GetPortfolio(portfolio.Id));
        }
    }
}
