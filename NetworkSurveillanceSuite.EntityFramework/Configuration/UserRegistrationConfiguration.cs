using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworkSurveillanceSuite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkSurveillanceSuite.EntityFramework.Configuration
{
    public class UserRegistrationConfiguration : EntityConfiguration<UserRegistration>
    {
        public override void Configure(EntityTypeBuilder<UserRegistration> builder)
        {
            builder.ToTable("UserRegistration", "dbo");

            builder.Property(d => d.Id)
                   .HasColumnName("UserRegistration_id");

            builder.Property(d => d.ClientName)
                       .HasColumnName("ClientName");

            builder.Property(d => d.EmailId)
                       .HasColumnName("EmailId");

            builder.Property(d => d.UserName)
                     .HasColumnName("UserName");

            builder.Property(d => d.Password)
                     .HasColumnName("Password");

            builder.Property(d => d.InsertDate)
                     .HasColumnName("InsertDate");

            builder.Property(d => d.UpdateDate)
                     .HasColumnName("UpdateDate");

            builder.Property(d => d.AdminFlag)
                     .HasColumnName("AdminFlag");

            builder.Property(d => d.DeleteFlag)
                     .HasColumnName("DeleteFlag");

        }
    }
}
