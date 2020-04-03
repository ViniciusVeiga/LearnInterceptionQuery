using DBContext.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiTenant.Controllers
{
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly TenantRepository _tenantRepository;

        public TenantController(TenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        [HttpGet]
        [Route("/tenants")]
        public IActionResult Get()
        {
            return Ok(_tenantRepository.GetTenants());
        }
    }
}
