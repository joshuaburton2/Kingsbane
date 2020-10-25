namespace Kingsbane.Database.Models
{
    public class DeckUpgrade
    {
        public int DeckId { get; set; }
        public virtual Deck Deck { get; set; }

        public int UpgradeId { get; set; }
        public virtual Upgrade Upgrade { get; set; }
    }
}
