using Kingsbane.Database.Enums;

namespace Kingsbane.Database.Models
{
    public class ResourcePrerequisite
    {
        public int UpgradeId { get; set; }
        public virtual Upgrade Upgrade { get; set; }

        public Resources ResourceId { get; set; }
        public virtual Resource Resource { get; set; }
    }
}
