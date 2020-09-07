using Kingsbane.Database.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kingsbane.Database.Models
{
    public class CardClass 
    {
        public CardClass()
        {
            Cards = new HashSet<Card>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public CardClasses Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        public Resources DominantResource { get; set; }
        public Resources SecondaryResource { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Description { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Playstyle { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Strengths { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Weaknesses { get; set; }

        // Related Entities

        public virtual ICollection<Card> Cards { get; set; }
    }
}
