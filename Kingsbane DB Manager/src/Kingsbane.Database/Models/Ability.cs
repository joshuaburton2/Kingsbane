using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kingsbane.Database.Models
{
    public class Ability 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Text { get; set; }

        public int? ResourceDevotion { get; set; }
        public int? ResourceEnergy { get; set; }
        public int? ResourceGold { get; set; }
        public int? ResourceKnowledge { get; set; }
        public int? ResourceMana { get; set; }
        public int? ResourceWild { get; set; }
        public int? ResourceNeutral { get; set; }

        public bool CostsAction { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        // Related Entities

        public virtual int CardId { get; set; }
        public virtual CardUnit Card { get; set; }  //Primary Client
    }
}
