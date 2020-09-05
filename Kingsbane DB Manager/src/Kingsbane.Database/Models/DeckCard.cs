namespace Kingsbane.Database.Models
{
    public class DeckCard
    {
        public int DeckId { get; set; }
        public virtual Deck Deck { get; set; }

        public int CardId { get; set; }
        public virtual Card Card { get; set; }
    }
}
