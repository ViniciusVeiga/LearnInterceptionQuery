﻿using Domain.Interfaces;
using System;

namespace Domain.Abstracts
{
    public abstract class HasTenant : IHasTenant
    {
        public Guid TenantId { get; private set; }

        public void SetTenantId(Guid tenantId)
        {
            TenantId = tenantId;
        }
    }
}
