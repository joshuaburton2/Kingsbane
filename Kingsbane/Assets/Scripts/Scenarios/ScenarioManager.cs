using Assets.Scripts.Scenarios;
using System.Collections;
using System.Collections.Generic;
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
}
