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
            BuildOptions();
            ListPeople();
        }

        static void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
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