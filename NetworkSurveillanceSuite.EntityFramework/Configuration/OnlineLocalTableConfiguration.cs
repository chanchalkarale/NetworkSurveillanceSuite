using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworkSurveillanceSuite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkSurveillanceSuite.EntityFramework.Configuration
{
    public class OnlineLocalTableConfiguration : EntityConfiguration<OnlineLocalTable>
    {
        public override void Configure(EntityTypeBuilder<OnlineLocalTable> builder)
        {
            builder.ToTable("Online_Local_Table", "dbo");

            builder.Property(a => a.Id)
                   .HasColumnName("Online_Local_Portal_id");

            builder.Property(a => a.OnlineLocalStatus)
                   .HasColumnName("Online_local_Status");

        }
    }
}