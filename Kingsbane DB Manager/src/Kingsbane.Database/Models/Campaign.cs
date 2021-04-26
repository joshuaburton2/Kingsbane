using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kingsbane.Database.Models
{
    public class Campaign
    {
        public Campaign()
        {
            Scenarios = new HashSet<Scenario>();
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

        //Related Entiries
        public virtual ICollection<Scenario> Scenarios { get; set; }
    }
}
