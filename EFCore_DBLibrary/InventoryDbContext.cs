using System;
using System.Collections.Generic;
using InventoryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace EFCore_DBLibrary
{
    public partial class InventoryDbContext : DbContext
    {
        private static IConfigurationRoot _configuration;

        public InventoryDbContext()
        {
        }

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json", true, true);
                _configuration = builder.Build();
                var connectionString = _configuration.GetConnectionString("InventoryManager");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
