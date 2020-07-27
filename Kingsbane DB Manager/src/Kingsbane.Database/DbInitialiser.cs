using System.Linq;
using System.Threading.Tasks;
using Kingsbane.Database.Models;

namespace Kingsbane.Database
{
    public static class DbInitialiser
    {
        public static async Task Initialize(KingsbaneContext context)
        {
            await context.Database.EnsureCreatedAsync();

            //if (context.Cards.Any())
            //    return;

            //await context.Cards.AddRangeAsync(
            //    new Card {Name = "Fred"},
            //    new Card {Name = "John"}
            //);
        }
    }
}
