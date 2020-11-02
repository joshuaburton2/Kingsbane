using Kingsbane.Database.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kingsbane.Database.Models
{
    public class Resource 
    {
        public Resource()
        {
            ClassResources = new HashSet<ClassResource>();
            ResourceProperties = new HashSet<ResourceProperty>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Resources Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Description { get; set; }

        // Related Entities
        public virtual ICollection<ClassResource> ClassResources { get; set; }
        public virtual ICollection<ResourceProperty> ResourceProperties { get; set; }
    }
}
