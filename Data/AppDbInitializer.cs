using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using myBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myBook.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope=applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "Spare",
                        Description = "For the first time, Prince Harry tells his own story, chronicling his journey with raw, unflinching honesty.A landmark publication, Spare is full of insight, revelation, self - examination, and hard - won wisdom about the eternal power of love over grief.",
                        Rate = 11970,
                        Genre = "Biography",
                        DateAdded = new DateTime(2023, 10, 1)
                    },
                    new Book()
                    {
                        Title = "The Creative Act: A Way of Being",
                        Description = "From the legendary music producer, a master at helping people connect with the wellsprings of their creativity, comes a beautifully crafted book many years in the making that offers that same deep wisdom to all of us.",
                        Rate = 11,
                        Genre = "Self-help",
                        DateAdded = new DateTime(2023, 10, 1)
                    }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
