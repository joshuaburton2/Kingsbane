namespace Kingsbane.Database.Models
{
    public class ScenarioRuleSet
    {
        public int ScenarioId { get; set; }
        public virtual Scenario Scenario { get; set; }

        public int RuleId { get; set; }
        public virtual ScenarioRule Rule { get; set; }
    }
}
