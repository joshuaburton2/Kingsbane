using Kingsbane.Database.Enums;

namespace Kingsbane.Database.Models
{
    public class MapTerrain
    {
        public int RowId { get; set; }
        public int ColumnId { get; set; }
        public TerrainTypes TerrainId { get; set; }

        // Related Entities
        public int MapId { get; set; }
        public Map Map { get; set; }
    }
}
