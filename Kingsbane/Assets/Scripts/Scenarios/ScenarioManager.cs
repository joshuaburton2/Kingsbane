using Assets.Scripts.Scenarios;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    private ScenarioLibrary ScenarioLibrary { get; set; }

    public void LoadScenarios()
    {
        //Load in the list of scenarios on the initialisation of the game
        ScenarioLibrary = new ScenarioLibrary();
        ScenarioLibrary.InitLibrary();
    }

    public Map GetMap(int id)
    {
        return ScenarioLibrary.MapList.FirstOrDefault(x => x.Id == id);
    }

    public Scenario GetScenario(int id)
    {
        return ScenarioLibrary.ScenarioList.FirstOrDefault(x => x.Id == id);
    }

    public Campaign GetCampaign(int id)
    {
        return ScenarioLibrary.CampaignList.FirstOrDefault(x => x.Id == id);
    }
}
