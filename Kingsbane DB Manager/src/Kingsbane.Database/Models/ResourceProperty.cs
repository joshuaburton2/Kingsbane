using Kingsbane.Database.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Kingsbane.Database.Models
{
    public class ResourceProperty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Resources ResourceType { get; set; }
        public ResourceProperties Type { get; set; }
        public int Value { get; set; }

        //Related Entities
        public int DeckId { get; set; }
        public virtual Deck Deck { get; set; }
    }
}
