using Kingsbane.Database.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Kingsbane.Database.Models
{
    public class ResourceProperty
    {
        public ResourceProperty()
        {
            DeckResourceProperties = new HashSet<DeckResourceProperty>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ResourcePropertyList Type { get; set; }

        //Related Entities
        public Resources ResourceId { get; set; }
        public virtual Resource Resource { get; set; }

        public virtual ICollection<DeckResourceProperty> DeckResourceProperties { get; set; }
    }
}
