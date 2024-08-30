using CatGacha.Models;
using System.ComponentModel.DataAnnotations;

namespace CatGacha.Data
{
    public class DbInitializer
    {
        public static void Initialize(GatchaContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var Users = new User[]
            {
                new User 
                {
                    Password = "default",
                    Username = "Testplayer",
                    Email = "jyrivaitmaa@gmail.com",
                    SignupAt = DateTime.Now,
                    IsDisabled = false,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                },
                new User
                {
                    Password = "default",
                    Username = "Testadmin",
                    Email = "jyrivaitmaa@gmail.com",
                    SignupAt = DateTime.Now,
                    IsDisabled = false,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                }
            };
            foreach ( var user in Users )
            {
                context.Users.Add( user );
            }
            context.SaveChanges();

            var cats = new Cat[]
            {
                new Cat
                {
                    Name = "Space Cat",
                    Description = "Outer space alien cat",
                    Zodiac = Zodiac.Rabbit,
                    Snack = "Moonpie",
                    Personality = "Does not know the concept of annoying. Has 3 braincell",
                    CatImageLink = "https://i.imgur.com/sNwNn9R.png"
                },
                new Cat
                {
                    Name = "Purple Cat",
                    Description = "Cannot see in the night",
                    Zodiac = Zodiac.Tiger,
                    Snack = "Sour apple candy",
                    Personality = "Protecc precius",
                    CatImageLink = "https://i.imgur.com/irYIIuN.png"
                },
                new Cat
                {
                    Name = "Fox",
                    Description = "Is not a cat",
                    Zodiac = Zodiac.Dog,
                    Snack = "Peanut cookie",
                    Personality = "Sneaky fox pretending to be a cat, also sneaky in other ways",
                    CatImageLink = "https://i.imgur.com/CETdGWX.png"
                }
            };
            foreach (var cat in cats)
            {
                context.Cats.Add(cat);
            }
            context.SaveChanges();

            var ownerships = new CatOwnership[]
            {
                new CatOwnership {UserID=1,CatID=1,OwnershipTotal=1},
                new CatOwnership {UserID=1,CatID=2,OwnershipTotal=2},
            };
            foreach (var ownership in ownerships)
            {
                context.CatOwnerships.Add(ownership);
            }
            context.SaveChanges();
        }
    }
}
