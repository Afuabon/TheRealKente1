using Microsoft.EntityFrameworkCore;
using TheRealKente.Models;

namespace TheRealKente.Data
{
    public static class InitializeData
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>());
            context.Database.EnsureCreated();

            if (context.Kentes.Any())

            {
                return;
            }
            context.Kentes.AddRange(new List<Kente>()
            {
                new()
                {
                    KenteID = "K001",
                    Description = "Red, yellow and white cotton handwoven fabric",
                    StockQuantity = 6,
                    KentePrice = 100.00,
                    ProductImageURL = "/Images/KenteK1p.png"
                },
                new()
                {
                    KenteID = "K002",
                    Description = "Green yellow and white handwoven cotton fabric",
                    StockQuantity = 5,
                    KentePrice = 100.00,
                    ProductImageURL = "/Images/KenteK2.jpg"
                },
                new()
                {
                    KenteID = "K003",
                    Description = "Blue burgundy and yellow cotton handwoven fabric with blue and orange silk threads",
                    StockQuantity = 2,
                    KentePrice = 150.00,
                    ProductImageURL = "/Images/KenteK3.jpg"
                },
                new()
                {
                    KenteID = "K004",
                    Description = "Silk Kente with Orange,Yellow, Grey and Gold handwoven fabric",
                    StockQuantity = 3,
                    KentePrice = 200.00,
                    ProductImageURL = "/Images/KenteK4.jpg"
                },
                new()
                {
                    KenteID = "K005",
                    Description = "Plain green Kente, handwoven fabric with gold silk rayon threads",
                    StockQuantity = 5,
                    KentePrice = 120.00,
                    ProductImageURL = "/Images/KenteK5.jpg"
                },
                new()
                {
                    KenteID = "K006",
                    Description = "Plain green Kente, with 4 yards of green, gold and white handwoven fabric",
                    StockQuantity = 4,
                    KentePrice = 150.00,
                    ProductImageURL = "/Images/KenteK6.jpg"

                },
                new()
                {
                    KenteID = "K007",
                    Description = "Brown and shimmery gold handwoven fabric",
                    StockQuantity = 5,
                    KentePrice = 120.00,
                    ProductImageURL = "/Images/KenteK7.jpg"
                },
                new()
                {
                    KenteID = "K008",
                    Description = "Green, Red, Black and Red handwoven fabric",
                    StockQuantity = 5,
                    KentePrice = 250.00,
                    ProductImageURL = "/Images/KenteK8.jpg"
                }


            });
            context.SaveChanges();


        }

    }
}
