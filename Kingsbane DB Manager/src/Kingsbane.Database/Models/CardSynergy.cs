namespace Kingsbane.Database.Models
{
    public class CardSynergy
    {
        public int CardId { get; set; }
        public virtual Card Card { get; set; }

        public int SynergyId { get; set; }
        public virtual Synergy Synergy { get; set; }
    }
}
