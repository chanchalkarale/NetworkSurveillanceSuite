using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworkSurveillanceSuite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkSurveillanceSuite.EntityFramework.Configuration
{
    public class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}
