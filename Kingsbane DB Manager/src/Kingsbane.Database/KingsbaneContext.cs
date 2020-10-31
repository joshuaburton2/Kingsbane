using System.Linq;
using Kingsbane.Database.Enums;
using Kingsbane.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Kingsbane.Database
{
    public class KingsbaneContext : DbContext
    {
        public KingsbaneContext(DbContextOptions<KingsbaneContext> options) : base(options) { }

        public KingsbaneContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<CardUnit> CardUnits { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<CardItem> CardItems { get; set; }
        public DbSet<CardSpell> CardSpells { get; set; }
        public DbSet<Synergy> Synergies { get; set; }
        public DbSet<CardSynergy> CardSynergies { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<CardTag> CardTags { get; set; }
        public DbSet<RelatedCards> RelatedCards { get; set; }
        public DbSet<Set> Set { get; set; }
        public DbSet<CardClass> CardClasses { get; set; }
        public DbSet<ClassResource> ClassResources { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<CardRarity> CardRarities { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<DeckCard> DeckCards { get; set; }
        public DbSet<Upgrade> Upgrades { get; set; }
        public DbSet<ClassPrerequisite> ClassPrerequisites { get; set; }
        public DbSet<ResourcePrerequisite> ResourcePrerequisites { get; set; }
        public DbSet<UpgradePrerequisite> UpgradePrerequisites { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Scenario> Scenarios { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<ScenarioRule> ScenarioRules { get; set; }
        public DbSet<ScenarioRuleSet> ScenarioRuleSets { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<DeckUpgrade> DeckUpgrades { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceProperty> ResourceProps { get; set; }
        public DbSet<DeckResourceProperty> DeckResourceProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Remove Cascade Delete on all entities
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<CardSynergy>()
                .HasKey(x => new { x.CardId, x.SynergyId });
            modelBuilder.Entity<CardTag>()
                .HasKey(x => new { x.CardId, x.TagId });
            modelBuilder.Entity<DeckCard>()
                .HasKey(x => new { x.DeckId, x.CardId });
            modelBuilder.Entity<RelatedCards>()
                .HasKey(x => new { x.CardId, x.RelatedCardId });

            modelBuilder.Entity<ResourcePrerequisite>()
                .HasKey(x => new { x.UpgradeId, x.ResourceId });
            modelBuilder.Entity<ClassPrerequisite>()
                .HasKey(x => new { x.UpgradeId, x.CardClassId });
            modelBuilder.Entity<UpgradePrerequisite>()
                .HasKey(x => new { x.UpgradeId, x.UpgradePrequisiteId });
            modelBuilder.Entity<DeckUpgrade>()
                .HasKey(x => new { x.DeckId, x.UpgradeId });

            modelBuilder.Entity<ScenarioRuleSet>()
                .HasKey(x => new { x.RuleId, x.ScenarioId });

            modelBuilder.Entity<ClassResource>()
                .HasKey(x => new { x.CardClassId, x.ResourceId });
        }
    }
}
