using Domain.Abstracts;
using Domain.Interfaces;
using System;

namespace Domain.Entity
{
    public class Portfolio : HasTenant
    {
        public Portfolio(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public virtual Tenant Tenant { get; private set; }
    }
}
