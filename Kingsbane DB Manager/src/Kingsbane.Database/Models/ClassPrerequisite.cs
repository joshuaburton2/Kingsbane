using Kingsbane.Database.Enums;

namespace Kingsbane.Database.Models
{
    public class ClassPrerequisite
    {
        public int UpgradeId { get; set; }
        public virtual Upgrade Upgrade { get; set; }

        public CardClasses CardClassId { get; set; }
        public virtual CardClass CardClass { get; set; }
    }
}
