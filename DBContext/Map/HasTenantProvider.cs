using Domain.Provider;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext.Map
{
    public abstract class HasTenantProvider
    {
        protected readonly TenantProvider _tenantProvider;

        public HasTenantProvider(TenantProvider tenantProvider)
        {
            _tenantProvider = tenantProvider;
        }
    }
}
