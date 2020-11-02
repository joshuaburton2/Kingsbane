using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kingsbane.App.Extensions;
using Kingsbane.Database;
using Kingsbane.Database.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

                var resourceString = $@"            Resources = new List<Resource>()
            {{
                {(item.ResourceDevotion.HasValue ? $"new Resource(CardResources.Devotion, {item.ResourceDevotion.Value})," : "")}
                {(item.ResourceEnergy.HasValue ? $"new Resource(CardResources.Energy, {item.ResourceEnergy.Value})," : "")}
                {(item.ResourceGold.HasValue ? $"new Resource(CardResources.Gold, {item.ResourceGold.Value})," : "")}
                {(item.ResourceKnowledge.HasValue ? $"new Resource(CardResources.Knowledge, {item.ResourceKnowledge.Value})," : "")}
                {(item.ResourceMana.HasValue ? $"new Resource(CardResources.Mana, {item.ResourceMana.Value})," : "")}
                {(item.ResourceWild.HasValue ? $"new Resource(CardResources.Wild, {item.ResourceWild.Value})," : "")}
                {(item.ResourceNeutral.HasValue ? $"new Resource(CardResources.Neutral, {item.ResourceNeutral.Value})," : "")}
            }},";
                resourceString = Regex.Replace(resourceString, @"\t|\n|\r", "");

                var abilityText = @$"        var ability{item.Id} = new AbilityData()
        {{
            Id = {item.Id},
            Name = ""{item.Name.FixQuotes()}"",
            Text = @""{item.Text.FixQuotes()}"",

            {resourceString}

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

                var resourceString = $@"            Resources = new List<Resource>()
            {{
                {(item.ResourceDevotion.HasValue ? $"new Resource(CardResources.Devotion, {item.ResourceDevotion.Value})," : "")}
                {(item.ResourceEnergy.HasValue ? $"new Resource(CardResources.Energy, {item.ResourceEnergy.Value})," : "")}
                {(item.ResourceGold.HasValue ? $"new Resource(CardResources.Gold, {item.ResourceGold.Value})," : "")}
                {(item.ResourceKnowledge.HasValue ? $"new Resource(CardResources.Knowledge, {item.ResourceKnowledge.Value})," : "")}
                {(item.ResourceMana.HasValue ? $"new Resource(CardResources.Mana, {item.ResourceMana.Value})," : "")}
                {(item.ResourceWild.HasValue ? $"new Resource(CardResources.Wild, {item.ResourceWild.Value})," : "")}
                {(item.ResourceNeutral.HasValue ? $"new Resource(CardResources.Neutral, {item.ResourceNeutral.Value})," : "")}
            }},";
                resourceString = Regex.Replace(resourceString, @"\t|\n|\r", "");

                var commonCard = @$"            Id = {item.Id},
            Name = ""{item.Name.FixQuotes()}"",
            ImageLocation = ""{item.ImageLocation}"",

            {resourceString}

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
                    case CardTypes.Unit:
                        var unit = item.Units.FirstOrDefault();

                        var unitAbilities = string.Join(",", unit.Abilities.Select(x => $"ability{x.Id}"));

                        sb.AppendLine($"        var card{item.Id} = new UnitData()");
                        sb.AppendLine("        {");
                        sb.AppendLine(commonCard);
                        sb.AppendLine($"            UnitTag = \"{unit?.UnitTag}\",");
                        sb.AppendLine($"            Attack = {unit?.Attack ?? 0},");
                        sb.AppendLine($"            Health = {unit?.Health ?? 0},");
                        sb.AppendLine($"            Range = {unit?.Range ?? 0},");
                        sb.AppendLine($"            Speed = {unit?.Speed ?? 0},");
                        sb.AppendLine($"");
                        sb.AppendLine($"            Abilities = new List<AbilityData>() {{{unitAbilities}}},");
                        sb.AppendLine("        };");
                        break;
                    case CardTypes.Spell:
                        var spell = item.Spells.FirstOrDefault();

                        sb.AppendLine($"        var card{item.Id} = new SpellData()");
                        sb.AppendLine("        {");
                        sb.AppendLine(commonCard);
                        sb.AppendLine($"            SpellType = \"{spell?.SpellType}\",");
                        sb.AppendLine($"            Range = {spell?.Range ?? 0},");
                        sb.AppendLine("        };");
                        break;
                    case CardTypes.Item:
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

            var query = _context.CardClasses
                .Include(x => x.ClassResources)
                .Include(x => x.Decks).ThenInclude(x => x.DeckCards)
                .Include(x => x.Decks).ThenInclude(x => x.ResourceProperties).ThenInclude(x => x.ResourceProperty)
                .Include(x => x.Decks).ThenInclude(x => x.DeckUpgrades);

            foreach (var item in query)
            {
                var isPlayable = item.IsPlayable.ToString().ToLower();

                var dominantResource = item.ClassResources.FirstOrDefault(x => x.ClassResourceType == ClassResourceTypes.Dominant).ResourceId;
                var secondaryResource = item.ClassResources.FirstOrDefault(x => x.ClassResourceType == ClassResourceTypes.Secondary).ResourceId;

                sb.AppendLine($"                //{item.Name}       (Dominant:{dominantResource}, Secondary:{secondaryResource})");
                sb.AppendLine($"                new ClassData(ClassList.{item.Name})");
                sb.AppendLine($"                {{");
                sb.AppendLine($"                    ClassResources = new List<ClassResourceType>()");
                sb.AppendLine($"                    {{");
                sb.AppendLine($"                        new ClassResourceType() {{ ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.{dominantResource} }},");
                sb.AppendLine($"                        new ClassResourceType() {{ ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.{secondaryResource} }},");
                sb.AppendLine($"                    }},");
                sb.AppendLine($"                    IsPlayable = {isPlayable},");
                sb.AppendLine($"                    DeckTemplates = new List<DeckSaveData>()");
                sb.AppendLine($"                    {{");
                foreach (var deck in item.Decks)
                {
                    var isNPCDeck = deck.NPCDeck.ToString().ToLower();

                    sb.AppendLine($"                        new DeckSaveData()");
                    sb.AppendLine($"                        {{");
                    sb.AppendLine($"                            Id = {deck.Id},");
                    sb.AppendLine(@$"                            Name = ""{deck.Name}"",");
                    sb.AppendLine($"                            DeckClass = ClassList.{item.Id},");
                    sb.AppendLine($"                            IsNPCDeck = {isNPCDeck},");
                    sb.AppendLine($"                            CardIdList = new List<int>()");
                    sb.AppendLine($"                            {{");
                    foreach (var card in deck.DeckCards)
                    {
                        sb.AppendLine($"                                {card.CardId}");
                    }
                    sb.AppendLine($"                            }},");
                    var commaText = deck.NPCDeck ? "" : ",";
                    sb.AppendLine($"                            UpgradeIdList = new List<int>(){commaText}");
                    if (deck.NPCDeck)
                    {
                        sb.AppendLine($"                            {{");
                        foreach (var upgrade in deck.DeckUpgrades)
                        {
                            sb.AppendLine($"                                {upgrade.UpgradeId},");
                        }
                        sb.AppendLine($"                            }},");
                        sb.AppendLine($"                            HeroCardID = {deck.HeroCardId},");
                        sb.AppendLine($"                            PlayerResources = new List<PlayerResource>()");
                        sb.AppendLine($"                            {{");
                        foreach (var resource in item.ClassResources)
                        {
                            var propertyOne = 0;
                            var propertyTwo = 0;

                            switch (resource.ResourceId)
                            {
                                case Resources.Devotion:
                                    propertyOne = deck.ResourceProperties.FirstOrDefault(x => x.ResourceProperty.Type == ResourcePropertyList.PrayerModifier).Value;
                                    propertyTwo = deck.ResourceProperties.FirstOrDefault(x => x.ResourceProperty.Type == ResourcePropertyList.LastingPrayer).Value;
                                    break;
                                case Resources.Energy:
                                    propertyOne = deck.ResourceProperties.FirstOrDefault(x => x.ResourceProperty.Type == ResourcePropertyList.BaseEnergyGain).Value;
                                    propertyTwo = deck.ResourceProperties.FirstOrDefault(x => x.ResourceProperty.Type == ResourcePropertyList.Surges).Value;
                                    break;
                                case Resources.Gold:
                                    propertyOne = deck.ResourceProperties.FirstOrDefault(x => x.ResourceProperty.Type == ResourcePropertyList.GoldValue).Value;
                                    propertyTwo = deck.ResourceProperties.FirstOrDefault(x => x.ResourceProperty.Type == ResourcePropertyList.BountyGain).Value;
                                    break;
                                case Resources.Knowledge:
                                    propertyOne = deck.ResourceProperties.FirstOrDefault(x => x.ResourceProperty.Type == ResourcePropertyList.BaseKnowledgeGain).Value;
                                    propertyTwo = deck.ResourceProperties.FirstOrDefault(x => x.ResourceProperty.Type == ResourcePropertyList.Stagnation).Value;
                                    break;
                                case Resources.Mana:
                                    propertyOne = deck.ResourceProperties.FirstOrDefault(x => x.ResourceProperty.Type == ResourcePropertyList.StartingMana).Value;
                                    propertyTwo = deck.ResourceProperties.FirstOrDefault(x => x.ResourceProperty.Type == ResourcePropertyList.Overload).Value;
                                    break;
                                case Resources.Wild:
                                    propertyOne = deck.ResourceProperties.FirstOrDefault(x => x.ResourceProperty.Type == ResourcePropertyList.WildGain).Value;
                                    propertyTwo = deck.ResourceProperties.FirstOrDefault(x => x.ResourceProperty.Type == ResourcePropertyList.MaxWild).Value;
                                    break;
                                case Resources.Neutral:
                                default:
                                    break;
                            }

                            sb.AppendLine($"                                new Player{resource.ResourceId}({propertyOne}, {propertyTwo}),");
                        }
                        sb.AppendLine($"                            }},");
                    }
                    sb.AppendLine($"                        }},");
                }
                sb.AppendLine($"                    }},");
                sb.AppendLine($"                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()");
                sb.AppendLine($"                    {{");
                sb.AppendLine($@"                        {{ ClassData.ClassDataFields.Description, ""{item.Description}"" }},");
                sb.AppendLine($@"                        {{ ClassData.ClassDataFields.Playstyle, ""{item.Playstyle}"" }},");
                sb.AppendLine($@"                        {{ ClassData.ClassDataFields.Strengths, ""{item.Strengths}"" }},");
                sb.AppendLine($@"                        {{ ClassData.ClassDataFields.Weaknesses, ""{item.Weaknesses}"" }},");
                sb.AppendLine($"                    }},");
                sb.AppendLine($"                }},");
            }

            sb.AppendLine("        };");

            var x = sb.ToString();

            Clipboard.SetText(x);
            MessageBox.Show("Exported content copied to clipboard");
        }

        private void btnUpgrades_Click(object sender, EventArgs e)
        {
            var formUpgradeList = _serviceProvider.GetRequiredService<formUpgradeList>();
            formUpgradeList.Show();
            this.Hide();
        }

        private void btnExportUpgrades_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();

            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using CategoryEnums;");
            sb.AppendLine("");
            sb.AppendLine("public class UpgradeLibrary");
            sb.AppendLine("{");
            sb.AppendLine("    public List<UpgradeData> UpgradeList { get; set; }");
            sb.AppendLine("");
            sb.AppendLine("    public void InitUpgradeList()");
            sb.AppendLine("    {");
            sb.AppendLine("        UpgradeList = new List<UpgradeData>();");

            var query = _context.Upgrades
                .Include(x => x.ResourcePrerequisites)
                .Include(x => x.ClassPrerequisites)
                .Include(x => x.UpgradePrerequisites);
            var upgradeTags = new List<string>();

            foreach (var item in query)
            {
                var tierLevelString = item.IsTierUpgrade ? $"Tier{item.TierLevel.ToString()}" : "Default";

                sb.AppendLine("");
                sb.AppendLine($"        var upgrade{item.Id} = new UpgradeData()");
                sb.AppendLine($"        {{");
                sb.AppendLine($"            Id = {item.Id},");
                sb.AppendLine(@$"            Name = ""{item.Name}"",");
                sb.AppendLine(@$"            Text = @""{item.Text.FixQuotes()}"",");
                sb.AppendLine($"            HonourPoints = {item.HonourPoints},");
                sb.AppendLine($"            IsRepeatable = {item.IsRepeatable.ToString().ToLower()},");
                sb.AppendLine($"            TierLevel = TierLevel.{tierLevelString},");

                sb.AppendLine($"            ResourcePrerequisites = new List<CardResources>()");
                sb.AppendLine($"            {{");
                foreach (var resourcePrerequisite in item.ResourcePrerequisites)
                {
                    sb.AppendLine($"                CardResources.{resourcePrerequisite.ResourceId},");
                }
                sb.AppendLine($"            }},");

                sb.AppendLine($"            ClassPrerequisites = new List<Classes.ClassList>()");
                sb.AppendLine($"            {{");
                foreach (var classPrerequisite in item.ClassPrerequisites)
                {
                    sb.AppendLine($"                CardResources.{classPrerequisite.CardClassId},");
                }
                sb.AppendLine($"            }},");
                sb.AppendLine($"            UpgradePrerequisites = new List<UpgradeData>(),");

                string upgradeTag;
                if (item.IsTierUpgrade)
                {
                    if (item.Name.Contains("Hero"))
                        upgradeTag = "HeroUpgrade";
                    else if (item.Name.Contains("Ability"))
                        upgradeTag = "AbilityUpgrade";
                    else
                    {
                        upgradeTag = item.Name.Replace(" ", "");
                        upgradeTag = upgradeTag.Replace("Tier", "");
                        upgradeTag = upgradeTag.Replace("I", "");
                    }
                }
                else
                {
                    upgradeTag = item.Name.Replace(" ", "");
                }
                if (!upgradeTags.Contains(upgradeTag))
                {
                    upgradeTags.Add(upgradeTag);
                }
                sb.AppendLine($"            UpgradeTag = UpgradeTags.{upgradeTag},");
                sb.AppendLine($"        }};");
                sb.AppendLine($"        UpgradeList.Add(upgrade{item.Id});");
            }

            sb.AppendLine("");

            foreach (var item in query)
            {
                var upgradePrerequisites = string.Join(",", item.UpgradePrerequisites.Select(x => $"upgrade{x.UpgradePrequisiteId}"));

                if (string.IsNullOrWhiteSpace(upgradePrerequisites))
                {
                    continue;
                }
                sb.AppendLine($"        upgrade{item.Id}.UpgradePrerequisites = new List<UpgradeData> {{{upgradePrerequisites}}};");
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");
            sb.AppendLine("");
            sb.AppendLine("namespace CategoryEnums");
            sb.AppendLine("{");
            sb.AppendLine("    public enum UpgradeTags");
            sb.AppendLine("    {");
            sb.AppendLine($"        {string.Join(",", upgradeTags)}");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            var x = sb.ToString();

            Clipboard.SetText(x);
            MessageBox.Show("Exported content copied to clipboard");
        }

        private void btnResources_Click(object sender, EventArgs e)
        {
            var formResources = _serviceProvider.GetRequiredService<formResources>();
            formResources.Show();
            this.Hide();
        }

        private void btnExportResources_Click(object sender, EventArgs e)
        {

        }

        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
