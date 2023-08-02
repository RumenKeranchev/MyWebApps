using Microsoft.EntityFrameworkCore;
using WebApp.RazorPages.Data;

namespace WebApp.RazorPages.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AppDbContext>>());

            if (context == null || context.Movies == null)
            {
                throw new ArgumentNullException("Null RazorDbContext");
            }

            // Look for any movies.
            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }

            context.Movies.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M,
                    Rating = "R"
                },

                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M,
                    Rating = "G"
                },

                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M,
                    Rating = "G"
                },

                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M,
                    Rating = "NA"
                }
            );

            context.Records.AddRange(
                new Record
                {
                    Duration = new TimeSpan(0, 2, 37),
                    Genre = "Rock",
                    PerformerName = "Jeris Johnson",
                    Title = "Kryptonite (Reloaded)",
                    Price = 0.99m
                },

                new Record
                {
                    Duration = new TimeSpan(0, 3, 31),
                    Genre = "Country",
                    PerformerName = "Jon Pardi",
                    Title = "Dirt On My Boots",
                    Price = 0.89m
                },
                
                new Record
                {
                    Duration = new TimeSpan(0, 3, 55),
                    Genre = "Country",
                    PerformerName = "Jessta James",
                    Title = "Hell's Coming with Me",
                    Price = 1.29m
                },
                
                new Record
                {
                    Duration = new TimeSpan(0, 4, 33),
                    Genre = "Heavy Metal",
                    PerformerName = "Metallica",
                    Title = "Too Far Gone?",
                    Price = 1.99m
                }
            );

            context.SaveChanges();
        }
    }
}
