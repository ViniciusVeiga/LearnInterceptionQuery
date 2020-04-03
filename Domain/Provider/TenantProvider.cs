using Domain.Interfaces;
using System;

namespace Domain.Provider
{
    public class TenantProvider
    {
        public TenantProvider(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
