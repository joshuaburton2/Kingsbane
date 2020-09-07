using System;
using System.Linq;
using System.Threading.Tasks;
using Kingsbane.Database.Enums;
using Kingsbane.Database.Models;

namespace Kingsbane.Database
{
    public static class DbInitialiser
    {
        public static async Task Initialize(KingsbaneContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (context.Set.Any())
                return;

            await context.Set.AddRangeAsync(
                    new Set { Name = "Default"},
                    new Set { Name = "Standard"}
                );

            foreach (var value in Enum.GetValues(typeof(CardClasses)).Cast<CardClasses>())
            {
                await context.CardClasses.AddAsync(new CardClass { Id = value, Name = value.ToString(), DominantResource = Resources.Neutral, SecondaryResource = Resources.Neutral,
                Description = "", Playstyle = "", Strengths = "", Weaknesses = "" });
            }

            foreach (var value in Enum.GetValues(typeof(CardRarities)).Cast<CardRarities>())
            {
                await context.CardRarities.AddAsync(new CardRarity { Id = value, Name = value.ToString() });
            }

            foreach (var value in Enum.GetValues(typeof(CardTypes)).Cast<CardTypes>())
            {
                await context.CardTypes.AddAsync(new CardType { Id = value, Name = value.ToString() });
            }

            await context.SaveChangesAsync();
        }
    }
}
