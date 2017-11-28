using Hackaton.Models;
using System.Collections.Generic;
using System.Linq;

namespace Hackaton.Data
{
    public class DroidDbInitializer
    {
        public static void Initialize(DroidContext context)
        {
            context.Database.EnsureCreated();

            if (context.Droids.Any())
            {
                return;
            }

            var droids = new List<Droid>
            {
                new Droid{ Name = "Vanilla" },
                new Droid{ Name = "Chocolade"  },
                new Droid{ Name = "Pistache" },
                new Droid{ Name = "Banana" },
                new Droid{ Name = "Strawberry" }

            };

            foreach (var droid in droids)
            {
                context.Droids.Add(droid);
            }

            context.SaveChanges();

        }
    }
}
