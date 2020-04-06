using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ITenant
    {
        Guid TenantId { get; }
        void SetTenantId(Guid tenantId);
    }
}
