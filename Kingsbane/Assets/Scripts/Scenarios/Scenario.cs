using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Objective
{
    public int Id { get; set; }
    public Color Color { get; set; }
}

public class Scenario
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Image DeploymentMap { get; set; }
    public Image ObjectivesMap { get; set; }
    public List<Objective> Objectives { get; set; }
    public List<int> RuleIds { get; set; }
    public List<ScenarioRule> Rules { get; set; }
    public int EnemyDeckId { get; set; }
    public DeckData EnemyDeck { get; set; }

}