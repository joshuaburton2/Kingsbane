using Assets.Scripts.Scenarios;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    private ScenarioLibrary ScenarioLibrary { get; set; }

    /// <summary>
    /// 
    /// Load the map, scenario and, campaign library in the external object
    /// 
    /// </summary>
    public void LoadScenarios()
    {
        //Load in the list of scenarios on the initialisation of the game
        ScenarioLibrary = new ScenarioLibrary();
        ScenarioLibrary.InitLibrary();
    }

    /// <summary>
    /// 
    /// Gets a map of a particular ID
    /// 
    /// </summary>
    public Map GetMap(int id)
    {
        return ScenarioLibrary.MapList.FirstOrDefault(x => x.Id == id);
    }

    /// <summary>
    /// 
    /// Get a list of all maps in the game
    /// 
    /// </summary>
    public List<Map> GetMaps()
    {
        return ScenarioLibrary.MapList;
    }

    /// <summary>
    /// 
    /// Gets a scemaro of a particular ID
    /// 
    /// </summary>
    public Scenario GetScenario(int id)
    {
        return ScenarioLibrary.ScenarioList.FirstOrDefault(x => x.Id == id);
    }

    /// <summary>
    /// 
    /// Gets a campaign of a particular ID
    /// 
    /// </summary>
    public Campaign GetCampaign(int id)
    {
        return ScenarioLibrary.CampaignList.FirstOrDefault(x => x.Id == id);
    }
}
