using Kingsbane.Database.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Kingsbane.Database.Models
{
    public class Deck
    {
        public Deck()
        {
            DeckCards = new HashSet<DeckCard>();
            DeckUpgrades = new HashSet<DeckUpgrade>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        public bool NPCDeck { get; set; }

        public int InitialHandSize { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        // Related Entities

        public int HeroCardId { get; set; }
        public virtual Card HeroCard { get; set; }

        public CardClasses DeckClassId { get; set; }
        public virtual CardClass DeckClass { get; set; }

        public virtual ICollection<DeckCard> DeckCards { get; set; }
        public virtual ICollection<DeckUpgrade> DeckUpgrades { get; set; }
        public virtual ICollection<ResourceProperty> ResourceProperties { get; set; }
    }
}
