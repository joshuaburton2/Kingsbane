namespace Kingsbane.Database.Models
{
    public class CardTag
    {
        public int CardId { get; set; }
        public virtual Card Card { get; set; }

        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
