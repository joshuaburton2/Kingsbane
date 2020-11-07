namespace Kingsbane.Database.Models
{
    public class MapObjective
    {
        public int RowId { get; set; }
        public int ColumnId { get; set; }
        public int? ObjectiveId { get; set; }

        // Related Entities
        public int ScenarioId { get; set; }
        public Scenario Scenario { get; set; }
    }
}
