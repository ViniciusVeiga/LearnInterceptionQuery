using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IHasTenant
    {
        void SetTenantId(Guid tenantId);
    }
}
