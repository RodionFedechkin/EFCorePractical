﻿using EFCore_DBLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCore_Activity0302
{
    internal class Program
    {
        private static IConfigurationRoot _configuration;
        private static DbContextOptionsBuilder<InventoryDbContext> _optionBuilder;

        static void Main(string[] args)
        {
            BuildOptions();
        }

        static void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionBuilder = new DbContextOptionsBuilder<InventoryDbContext>();
            _optionBuilder.UseSqlServer(_configuration.GetConnectionString("InventoryManager"));
        }
    }
}