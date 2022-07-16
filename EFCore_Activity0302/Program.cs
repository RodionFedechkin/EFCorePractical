using EFCore_DBLibrary;
using InventoryModels;
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
            EnsureItems();
            ListInventory();
        }

        static void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionBuilder = new DbContextOptionsBuilder<InventoryDbContext>();
            _optionBuilder.UseSqlServer(_configuration.GetConnectionString("InventoryManager"));
        }

        static void EnsureItems()
        {
            EnsureItem("Batman begins");
            EnsureItem("Inception");
            EnsureItem("Remember the Titans");
            EnsureItem("Star Wars: The Empire strikes back");
            EnsureItem("Top Gun");

        }

        static void EnsureItem(string name)
        {
            using (var db = new InventoryDbContext(_optionBuilder.Options))
            {
                var existingItem = db.Items.FirstOrDefault(item => item.Name.ToLower() == name.ToLower());
                if (existingItem == null)
                {
                    var item = new Item
                    {
                        Name = name
                    };
                    db.Items.Add(item);
                    db.SaveChanges();
                }
            }
        }

        static void ListInventory()
        {
            using (var db = new InventoryDbContext(_optionBuilder.Options))
            {
                var items = db.Items.OrderBy(item => item.Name).ToList();
                items.ForEach(item => Console.WriteLine(item.Name));
            }
        }
    }
}