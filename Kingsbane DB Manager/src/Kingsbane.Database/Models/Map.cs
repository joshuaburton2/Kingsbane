using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kingsbane.Database.Models
{
    public class Map
    {
        public Map()
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
        public string Decription { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string ColourMapName { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        //Related Entities
        public virtual ICollection<Scenario> Scenarios { get; set; }
        public virtual ICollection<MapTerrain> TerrainMap { get; set; }
    }
}
