using System.ComponentModel.DataAnnotations.Schema;

namespace Kingsbane.Database.Models
{
    public class RelatedCards
    {
        public int CardId { get; set; }
        public virtual Card Card { get; set; }

        [ForeignKey(nameof(RelatedCard))]
        public int RelatedCardId { get; set; }
        public virtual Card RelatedCard { get; set; }
    }
}
