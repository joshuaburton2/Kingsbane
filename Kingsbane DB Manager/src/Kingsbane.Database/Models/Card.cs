using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Kingsbane.Database.Enums;

namespace Kingsbane.Database.Models
{
    public class Card
    {
        public Card()
        {
            Items = new HashSet<CardItem>();
            Spells = new HashSet<CardSpell>();
            Units = new HashSet<CardUnit>();
            Synergies = new HashSet<CardSynergy>();
            Tags = new HashSet<CardTag>();
            RelatedCards = new HashSet<RelatedCards>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string ImageLocation { get; set; }

        public int? ResourceDevotion { get; set; }
        public int? ResourceEnergy { get; set; }
        public int? ResourceGold { get; set; }
        public int? ResourceKnowledge { get; set; }
        public int? ResourceMana { get; set; }
        public int? ResourceWild { get; set; }
        public int? ResourceNeutral { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Text { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Notes { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string LoreText { get; set; }


        [Timestamp]
        public byte[] RowVersion { get; set; }

        // Related Entities

        public int SetId { get; set; }
        public virtual Set Set { get; set; }
        public CardClasses CardClassId { get; set; }
        public virtual CardClass CardClass { get; set; }
        public CardRarities RarityId { get; set; }
        public virtual CardRarity Rarity { get; set; }
        public CardTypes CardTypeId { get; set; }
        public virtual CardType CardType { get; set; }

        public virtual ICollection<CardItem> Items { get; set; }
        public virtual ICollection<CardSpell> Spells { get; set; }
        public virtual ICollection<CardUnit> Units { get; set; }
        public virtual ICollection<CardSynergy> Synergies { get; set; }
        public virtual ICollection<CardTag> Tags { get; set; }
        public virtual ICollection<DeckCard> DeckCards { get; set; }
        [InverseProperty("Card")]
        public virtual ICollection<RelatedCards> RelatedCards { get; set; }
    }
}
