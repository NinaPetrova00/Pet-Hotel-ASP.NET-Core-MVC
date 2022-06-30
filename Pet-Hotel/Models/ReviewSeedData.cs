using Microsoft.EntityFrameworkCore;
using Pet_Hotel.Data;

namespace Pet_Hotel.Models
{
    public class ReviewSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Pet_HotelContext(
               serviceProvider.GetRequiredService<DbContextOptions<Pet_HotelContext>>()))
            {

                if (context.Review.Any())
                {
                    return;
                }

                context.Review.AddRange(
                    new Review
                    {
                        Username = "Ivan",
                        Description = "I really liked the hotel!",
                        Rating = "*****"
                    },
                    new Review
                    {
                        Username = "Maria",
                        Description = "My best friend felt so good in this magical place!",
                        Rating = "*****"
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
