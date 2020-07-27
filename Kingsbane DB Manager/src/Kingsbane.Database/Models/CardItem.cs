using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kingsbane.Database.Models
{
    public class CardItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[ForeignKey(nameof(Card))]
        public int CardId { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string ItemTag { get; set; }

        public int Durability { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        // Related Entities

        public virtual Card Card { get; set; }              // Primary Client
    }
}
