using Kingsbane.Database.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kingsbane.Database.Models
{
    public class Keyword
    {
        public Keyword()
        {
            UnitKeywords = new HashSet<UnitKeyword>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Description { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        // Related Entities

        public virtual ICollection<UnitKeyword> UnitKeywords { get; set; }
    }
}
