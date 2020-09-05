using Kingsbane.Database.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Kingsbane.Database.Models
{
    public class Deck
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        public bool PlayerDeck { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        // Related Entities

        public CardClasses DeckClassId { get; set; }
        public virtual CardClass DeckClass { get; set; }

        public virtual ICollection<DeckCard> DeckCards { get; set; }
    }
}
