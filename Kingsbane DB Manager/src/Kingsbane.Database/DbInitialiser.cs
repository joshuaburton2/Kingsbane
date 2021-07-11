using System;
using System.Linq;
using System.Threading.Tasks;
using Kingsbane.Database.Enums;
using Kingsbane.Database.Models;

namespace Kingsbane.Database
{
    public static class DbInitialiser
    {
        //If moving Database to new computer, in order to edit properly, use the following query
        //alter authorization on database::Kingsbane to [username]

        public static async Task Initialize(KingsbaneContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (context.Set.Any())
                return;

            await context.Set.AddRangeAsync(
                    new Set { Name = "Default"},
                    new Set { Name = "Standard"}
                );

            foreach (var value in Enum.GetValues(typeof(Resources)).Cast<Resources>())
            {
                await context.Resources.AddAsync(new Resource() { Id = value, Name = value.ToString(), Description = ""});
            }

            foreach (var value in Enum.GetValues(typeof(CardClasses)).Cast<CardClasses>())
            {
                await context.CardClasses.AddAsync(new CardClass { Id = value, Name = value.ToString(), 
                Description = "", Playstyle = "", Strengths = "", Weaknesses = "", IsPlayable = false });
            }

            foreach (var value in Enum.GetValues(typeof(CardRarities)).Cast<CardRarities>())
            {
                await context.CardRarities.AddAsync(new CardRarity { Id = value, Name = value.ToString() });
            }

            foreach (var value in Enum.GetValues(typeof(CardTypes)).Cast<CardTypes>())
            {
                await context.CardTypes.AddAsync(new CardType { Id = value, Name = value.ToString() });
            }

            foreach (var value in Enum.GetValues(typeof(Keywords)).Cast<Keywords>())
            {
                await context.Keywords.AddAsync(new Keyword { Id = (int)value, Name = value.ToString() });
            }

            await context.SaveChangesAsync();
        }
    }
}
