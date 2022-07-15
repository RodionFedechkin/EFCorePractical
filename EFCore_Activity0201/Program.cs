using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EFCore_DBLibrary;

namespace EFCore_Activity0201
{
    internal class Program
    {
        private static IConfigurationRoot _configuration;
        private static DbContextOptionsBuilder<AdventureWorks2017Context> _optionBuilder;

        static void Main(string[] args)
        {
            BuildConfiguration();
            BuildOptions();
            ListPeople();
        }

        static void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);
            _configuration = builder.Build();
        }

        static void BuildOptions()
        {
            _optionBuilder = new DbContextOptionsBuilder<AdventureWorks2017Context>();
            _optionBuilder.UseSqlServer(_configuration.GetConnectionString("AdventureWorks"));
        }
        
        static void ListPeople()
        {
            using(var db = new AdventureWorks2017Context(_optionBuilder.Options))
            {
                var people = db.People.OrderByDescending(x => x.LastName).Take(20);
                foreach (var person in people)
                {
                    Console.WriteLine($"{person.FirstName} {person.LastName}");
                }
            }
        }
    }
}