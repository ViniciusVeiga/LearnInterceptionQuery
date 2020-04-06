using Domain.Interfaces;
using System;

namespace Domain.Abstracts
{
    public abstract class HasTenant : ITenant
    {
        public Guid TenantId { get; private set; }

        public void SetTenantId(Guid tenantId)
        {
            TenantId = tenantId;
        }
    }
}
