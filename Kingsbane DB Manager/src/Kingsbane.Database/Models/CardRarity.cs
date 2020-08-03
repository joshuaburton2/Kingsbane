using Kingsbane.Database.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kingsbane.Database.Models
{
    public class CardRarity 
    {
        public CardRarity()
        {
            Cards = new HashSet<Card>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public CardRarities Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        // Related Entities

        public virtual ICollection<Card> Cards { get; set; }
    }
}
