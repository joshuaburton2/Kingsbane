using Kingsbane.Database.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kingsbane.Database.Models
{
    public class Upgrade
    {
        public Upgrade()
        {
            ResourcePrerequisites = new HashSet<ResourcePrerequisite>();
            ClassPrerequisites = new HashSet<ClassPrerequisite>();
            UpgradePrerequisites = new HashSet<UpgradePrerequisite>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Text { get; set; }

        public int HonourPoints { get; set; }
        public bool IsRepeatable { get; set; }
        public bool IsTierUpgrade { get; set; }
        public int? TierLevel { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        // Related Entities

        public int SetId { get; set; }
        public virtual Set Set { get; set; }

        public virtual ICollection<ResourcePrerequisite> ResourcePrerequisites { get; set; }
        public virtual ICollection<ClassPrerequisite> ClassPrerequisites { get; set; }

        [InverseProperty("Upgrade")]
        public virtual ICollection<UpgradePrerequisite> UpgradePrerequisites { get; set; }

        public virtual ICollection<DeckUpgrade> DeckUpgrades { get; set; }
    }
}
