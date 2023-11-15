using Examen.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Net.Data
{

    public static class Initializer
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                // Voeg initiële gebruikers toe indien nodig
                var user1 = new User { Username = "User1", Password = "Pass1" };
                var user2 = new User { Username = "User2", Password = "Pass2" };

                context.Users.AddRange(user1, user2);
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                // Voeg initiële producten toe indien nodig
                var products = new List<Product>
                {
                    new Product { Name = "Logo-ontwerp", Price = 100.0m },
                    new Product { Name = "Flyer-ontwerp", Price = 50.0m },
                    new Product { Name = "Visitekaartjes", Price = 25.0m },
                    new Product { Name = "Banners", Price = 75.0m },
                    new Product { Name = "Sociale media afbeeldingen", Price = 40.0m },
                    new Product { Name = "Andere grafische elementen", Price = 60.0m }
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }

            // Voeg hier eventueel initiële gegevens toe voor Orders
        }
    }
}
