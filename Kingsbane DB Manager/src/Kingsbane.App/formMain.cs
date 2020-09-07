using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using Kingsbane.App.Extensions;
using Kingsbane.Database;
using Kingsbane.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

// ref: https://marcominerva.wordpress.com/2020/03/09/using-hostbuilder-serviceprovider-and-dependency-injection-with-windows-forms-on-net-core-3/

namespace Kingsbane.App
{
    public partial class formMain : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly KingsbaneContext _context;

        public formMain(
            IServiceProvider serviceProvider,
            KingsbaneContext context)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _context = context;
        }

        private void buttonCardList_Click(object sender, System.EventArgs e)
        {
            var formCardList = _serviceProvider.GetRequiredService<formCardList>();
            formCardList.Show();
            this.Hide();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using CategoryEnums;");
            sb.AppendLine("");
            sb.AppendLine("public class CardLibrary");
            sb.AppendLine("{");
            sb.AppendLine("    public List<CardData> CardList { get; private set; }");
            sb.AppendLine("    public List<AbilityData> AbilityList { get; private set; }");
            sb.AppendLine("");
            sb.AppendLine("    public void InitLibrary()");
            sb.AppendLine("    {");
            sb.AppendLine("        CardList = new List<CardData>();");
            sb.AppendLine("        AbilityList = new List<AbilityData>();");
            sb.AppendLine("");



            var abilityQuery = _context.Abilities;

            foreach (var item in abilityQuery)
            {
                var costsAction = item.CostsAction.ToString().ToLower();
                var abilityText = @$"        var ability{item.Id} = new AbilityData()
        {{
            Id = {item.Id},
            Name = ""{item.Name}"",
            Text = @""{item.Text.FixQuotes()}"",

            ResourceDevotion = {item.ResourceDevotion.ToNullableInt()},
            ResourceEnergy = {item.ResourceEnergy.ToNullableInt()},
            ResourceGold = {item.ResourceGold.ToNullableInt()},
            ResourceKnowledge = {item.ResourceKnowledge.ToNullableInt()},
            ResourceMana = {item.ResourceMana.ToNullableInt()},
            ResourceWild = {item.ResourceWild.ToNullableInt()},
            ResourceNeutral = {item.ResourceNeutral.ToNullableInt()},

            CostsAction = {costsAction},
        }};
            AbilityList.Add(ability{item.Id}); ";
                sb.AppendLine(abilityText);
                sb.AppendLine("");
            }



            var query = _context.Cards
                .Include(x => x.Tags).ThenInclude(x => x.Tag)
                .Include(x => x.Synergies).ThenInclude(x => x.Synergy)
                .Include(x => x.RelatedCards).ThenInclude(x => x.RelatedCard)
                .Include(x => x.Set)
                .Include(x => x.Units)
                .Include(x => x.Spells)
                .Include(x => x.Items);

            foreach (var item in query)
            {
                var cardTags = string.Join(",", item.Tags.Select(x => $"Tags.{x.Tag.Name}"));
                var cardSynergies = string.Join(",", item.Synergies.Select(x => $"Synergies.{x.Synergy.Name}"));

                var commonCard = @$"            Id = {item.Id},
            Name = ""{item.Name}"",
            ImageLocation = ""{item.ImageLocation}"",

            ResourceDevotion = {item.ResourceDevotion.ToNullableInt()},
            ResourceEnergy = {item.ResourceEnergy.ToNullableInt()},
            ResourceGold = {item.ResourceGold.ToNullableInt()},
            ResourceKnowledge = {item.ResourceKnowledge.ToNullableInt()},
            ResourceMana = {item.ResourceMana.ToNullableInt()},
            ResourceWild = {item.ResourceWild.ToNullableInt()},
            ResourceNeutral = {item.ResourceNeutral.ToNullableInt()},

            Text = @""{item.Text.FixQuotes()}"",
            LoreText = @""{item.LoreText.FixQuotes()}"",
            Notes = @""{item.Notes.FixQuotes()}"",

            Set = Sets.{item.Set.Name},
            Class = Classes.ClassList.{item.CardClassId},
            Rarity = Rarity.{item.RarityId},
            CardType = CardTypes.{item.CardTypeId},

            Tags = new List<Tags> {{{cardTags}}},
            Synergies = new List<Synergies>{{{cardSynergies}}},";

                switch (item.CardTypeId)
                {
                    case Database.Enums.CardTypes.Unit:
                        var unit = item.Units.FirstOrDefault();

                        var unitAbilities = string.Join(",", unit.Abilities.Select(x => $"ability{x.Id}"));

                        sb.AppendLine($"        var card{item.Id} = new UnitData()");
                        sb.AppendLine("        {");
                        sb.AppendLine(commonCard);
                        sb.AppendLine($"            UnitTag = \"{unit?.UnitTag}\",");
                        sb.AppendLine($"            Attack = {unit?.Attack??0},");
                        sb.AppendLine($"            Health = {unit?.Health ?? 0},");
                        sb.AppendLine($"            Range = {unit?.Range ?? 0},");
                        sb.AppendLine($"            Speed = {unit?.Speed ?? 0},");
                        sb.AppendLine($"");
                        sb.AppendLine($"            Abilities = new List<AbilityData>() {{{unitAbilities}}},");
                        sb.AppendLine("        };");
                        break;
                    case Database.Enums.CardTypes.Spell:
                        var spell = item.Spells.FirstOrDefault();

                        sb.AppendLine($"        var card{item.Id} = new SpellData()");
                        sb.AppendLine("        {");
                        sb.AppendLine(commonCard);
                        sb.AppendLine($"            SpellType = \"{spell?.SpellType}\",");
                        sb.AppendLine($"            Range = {spell?.Range ?? 0},");
                        sb.AppendLine("        };");
                        break;
                    case Database.Enums.CardTypes.Item:
                        var cardItem = item.Items.FirstOrDefault();

                        sb.AppendLine($"        var card{item.Id} = new ItemData()");
                        sb.AppendLine("        {");
                        sb.AppendLine(commonCard);
                        sb.AppendLine($"            ItemTag = \"{cardItem?.ItemTag}\",");
                        sb.AppendLine($"            Durability = {cardItem?.Durability ?? 0},");
                        sb.AppendLine("        };");

                        break;
                    default:
                        continue;
                }

                sb.AppendLine($"        CardList.Add(card{item.Id});");
                sb.AppendLine("");
            }

            foreach (var item in query)
            {
                //_context.RelatedCards.Where(x => x.CardId == item.Id).
                var relatedCards = string.Join(",", item.RelatedCards.Select(x => $"card{x.RelatedCardId}"));

                if (string.IsNullOrWhiteSpace(relatedCards))
                {
                    continue;
                }
                sb.AppendLine($"        card{item.Id}.RelatedCards = new List<CardData> {{{relatedCards}}};");
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");
            sb.AppendLine("");
            sb.AppendLine("namespace CategoryEnums");
            sb.AppendLine("{");
            sb.AppendLine("    public enum Tags");
            sb.AppendLine("    {");
            sb.AppendLine($"         Default, {string.Join(",", _context.Tags.Select(x => x.Name))}");
            sb.AppendLine("    }");
            sb.AppendLine("");
            sb.AppendLine("    public enum Synergies");
            sb.AppendLine("    {");
            sb.AppendLine($"         Default, {string.Join(",", _context.Synergies.Select(x => x.Name))}");
            sb.AppendLine("    }");
            sb.AppendLine("");
            sb.AppendLine("    public enum Sets");
            sb.AppendLine("    {");
            sb.AppendLine($"         {string.Join(",", _context.Set.Select(x => x.Name))}");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            var x = sb.ToString();

            Clipboard.SetText(x);
            MessageBox.Show("Exported content copied to clipboard");
        }

        private void btnClassList_Click(object sender, EventArgs e)
        {
            var formEditClass = _serviceProvider.GetRequiredService<formEditClasses>();
            formEditClass.Show();
            this.Hide();
        }

        private void btnExportClasses_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();

            sb.AppendLine("        internal static List<ClassData> ClassDataList = new List<ClassData>()");
            sb.AppendLine("        {");

            var query = _context.CardClasses;

            foreach (var item in query)
            {
                sb.AppendLine($"                //{item.Name}       (Dominant:{item.DominantResource}, Secondary:{item.SecondaryResource})");
                sb.AppendLine($"                new ClassData(ClassList.{item.Name})");
                sb.AppendLine($"                {{");
                sb.AppendLine($"                    ClassResources = new List<ClassResourceType>()");
                sb.AppendLine($"                    {{");
                sb.AppendLine($"                        new ClassResourceType() {{ ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.{item.DominantResource} }},");
                sb.AppendLine($"                        new ClassResourceType() {{ ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.{item.SecondaryResource} }},");
                sb.AppendLine($"                    }},");
                sb.AppendLine($"                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()");
                sb.AppendLine($"                    {{");
                sb.AppendLine($@"                        {{ ClassData.ClassDataFields.Description, ""{item.Description}"" }},");
                sb.AppendLine($@"                        {{ ClassData.ClassDataFields.Playstyle, ""{item.Playstyle}"" }},");
                sb.AppendLine($@"                        {{ ClassData.ClassDataFields.Strengths, ""{item.Strengths}"" }},");
                sb.AppendLine($@"                        {{ ClassData.ClassDataFields.Weaknesses, ""{item.Weaknesses}"" }},");
                sb.AppendLine($"                    }},");
                sb.AppendLine($"                    }},");
            }

            sb.AppendLine("        };");

            var x = sb.ToString();

            Clipboard.SetText(x);
            MessageBox.Show("Exported content copied to clipboard");
        }
    }
}
