namespace Kingsbane.Database.Models
{
    public class MapDeployment
    {
        public int RowId { get; set; }
        public int ColumnId { get; set; }
        public int? PlayerId { get; set; }

        // Related Entities
        public int ScenarioId { get; set; }
        public Scenario Scenario { get; set; }
    }
}
