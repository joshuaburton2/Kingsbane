using Kingsbane.Database.Enums;

namespace Kingsbane.Database.Models
{
    public class UnitKeyword
    {
        public int CardUnitId { get; set; }
        public virtual CardUnit CardUnit { get; set; }

        public Keywords KeywordId { get; set; }
        public virtual Keyword Keyword { get; set; }
    }
}
