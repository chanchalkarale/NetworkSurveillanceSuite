using Microsoft.EntityFrameworkCore;
using NetworkSurveillanceSuite.Domain.Models;
using NetworkSurveillanceSuite.EntityFramework.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NetworkSurveillanceSuite.EntityFramework
{
    public class NetworkSurveillanceSuiteContext : DbContext
    {
        public NetworkSurveillanceSuiteContext(DbContextOptions<NetworkSurveillanceSuiteContext> options) : base(options)
        {

        }

        public DbSet<OnlineLocalTable> OnlineLocalTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Test
            modelBuilder.ApplyConfiguration(new OnlineLocalTableConfiguration());
        }
    }
}
