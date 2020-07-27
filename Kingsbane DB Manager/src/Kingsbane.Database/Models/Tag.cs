using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kingsbane.Database.Models
{
    public class Tag
    {
        public Tag()
        {
            Cards = new HashSet<CardTag>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100) ")]
        public string Name { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        // Related Entities

        public virtual ICollection<CardTag> Cards { get; set; }
    }
}
