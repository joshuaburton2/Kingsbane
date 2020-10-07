using System.ComponentModel.DataAnnotations.Schema;

namespace Kingsbane.Database.Models
{
    public class UpgradePrerequisite
    {
        public int UpgradeId { get; set; }
        public virtual Upgrade Upgrade { get; set; }

        [ForeignKey(nameof(UpgradePrequisite))]
        public int UpgradePrequisiteId { get; set; }
        public virtual Upgrade UpgradePrequisite { get; set; }
    }
}
