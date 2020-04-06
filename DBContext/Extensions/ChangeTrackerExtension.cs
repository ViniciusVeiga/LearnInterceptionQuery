using Domain.Abstracts;
using Domain.Interfaces;
using Domain.Provider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;

namespace DBContext.Extensions
{
    public static class ChangeTrackerExtension
    {
        public static void ProcessCreation(this ChangeTracker changeTracker, TenantProvider tenantProvider)
        {
            changeTracker
                .Entries<ITenant>()
                .Where(e => e.State == EntityState.Added)
                .ToList()
                .ForEach(e => e.Entity.SetTenantId(tenantProvider.GetTenantId()));
        }

    }
}
