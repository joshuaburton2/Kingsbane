using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CampaignManagerUI : MonoBehaviour
{
    private DeckData loadedDeck;
    private Campaign loadedCampaign;
    public Scenario selectedScenario;

    [Header("Campaign Details Area")]
    [SerializeField]
    private TextMeshProUGUI campaignNameText;
    [SerializeField]
    private TextMeshProUGUI campaignDescriptionText;
    [SerializeField]
    private TextMeshProUGUI campaignLengthText;
    [SerializeField]
    private GameObject scenarioListParent;
    [SerializeField]
    private GameObject scenarioListPrefab;

    [Header("Scenario Details Area")]
    [SerializeField]
    private TextMeshProUGUI mapDescriptionText;
    [SerializeField]
    private TextMeshProUGUI scenarioDescriptionText;
    [SerializeField]
    private MapKeyUI mapKey;
    [SerializeField]
    private GameObject ruleListParent;
    [SerializeField]
    private GameObject ruleDisplayPrefab;
    private List<GameObject> ruleObjectList;
    [SerializeField]
    private TextMeshProUGUI enemyHeroNameText;
    [SerializeField]
    private TextMeshProUGUI enemyClassNameText;
    [SerializeField]
    private GameObject enemyHeroParent;
    [SerializeField]
    private GameObject enemyDeckDetailsArea;
    [SerializeField]
    private DeckListObject enemyDeckList;

    [Header("Player Deck Area")]
    [SerializeField]
    private DeckListObject playerDeckList;
    [SerializeField]
    private TextMeshProUGUI honourPointsText;

    [Header("Play Buttons")]
    [SerializeField]
    private Button playButton;

    public void InitialiseCampaignManager(DeckData deckData)
    {
        if (!deckData.IsCampaign)
            throw new Exception("Deck is invalid to manage- not a campaign deck");

        loadedDeck = deckData;
        loadedCampaign = deckData.CampaignTracker.GetCampaign();

        campaignNameText.text = loadedCampaign.Name;
        campaignDescriptionText.text = loadedCampaign.Description;
        campaignLengthText.text = loadedCampaign.Scenarios.Count.ToString();

        GameManager.DestroyAllChildren(scenarioListParent);
        for (int index = 0; index < Mathf.Min(loadedCampaign.Scenarios.Count, loadedDeck.CampaignTracker.CompletedScenarios + 1); index++)
        {
            var scenario = loadedCampaign.Scenarios[index];
            var scenarioListObject = Instantiate(scenarioListPrefab, scenarioListParent.transform);
            var scenarioListScript = scenarioListObject.GetComponent<ScenarioListObject>();
            scenarioListScript.InitScenarioListObject(this, index + 1, scenario);
            scenarioListObject.name = $"Scenario: {scenario.Name}";
        }

        selectedScenario = loadedDeck.CampaignTracker.GetCurrentScenario();
        RefreshSelectedScenario();

        RefreshPlayerDetails();
    }

    public void RefreshSelectedScenario()
    {
        if (selectedScenario.EnemyDeck == null)
        {
            throw new Exception("Scenario is not valid for the campaign");
        }

        mapDescriptionText.text = selectedScenario.Map.Description;
        scenarioDescriptionText.text = selectedScenario.Description;

        //Creates the list of rules for the scenario
        GameManager.DestroyAllChildren(ruleListParent);
        ruleObjectList = new List<GameObject>();
        foreach (var rule in selectedScenario.Rules)
        {
            var ruleObject = Instantiate(ruleDisplayPrefab, ruleListParent.transform);
            ruleObject.GetComponent<RuleDisplayObject>().RefreshRuleDisplay(rule, _campaignManagerUI: this);
            ruleObjectList.Add(ruleObject);
        }

        enemyHeroNameText.text = $"<b>Hero:</b> {selectedScenario.EnemyDeck.HeroCard.Name}";
        enemyClassNameText.text = $"<b>Class: </b>{selectedScenario.EnemyDeck.DeckClass.GetEnumDescription()}";

        GameManager.DestroyAllChildren(enemyHeroParent);
        GameManager.instance.libraryManager.CreateCardObject(selectedScenario.EnemyDeck.HeroCard, enemyHeroParent.transform, 0.35f);
        enemyDeckList.InitDeckListObject(selectedScenario.EnemyDeck, _campaignManagerUI: this, hideCards: true);
        enemyDeckDetailsArea.SetActive(false);

        GameManager.instance.mapGrid.RefreshGrid(selectedScenario.Map, selectedScenario.Id.Value);

        playButton.interactable = !loadedDeck.CampaignTracker.CompletedCampaign && selectedScenario.Id == loadedDeck.CampaignTracker.GetCurrentScenario().Id;
    }

    /// <summary>
    /// 
    /// Refreshes the rule list. If wanting only a particular rule to be shown (such as when a rule is selected)
    /// then need to provide an ID of the rule in the list
    /// 
    /// </summary>
    /// <param name="id"></param>
    public void RefreshRuleList(int? id = null)
    {
        foreach (var ruleObject in ruleObjectList)
        {
            if (id.HasValue)
                if (ruleObject.GetComponent<RuleDisplayObject>().rule.Id != id)
                {
                    ruleObject.SetActive(false);
                }
                else
                {
                    ruleObject.SetActive(true);
                }
            else
            {
                ruleObject.SetActive(true);
            }
        }
    }

    public void SelectScenario(Scenario scenario)
    {
        selectedScenario = scenario;
        RefreshSelectedScenario();
    }

    public void EnemyDeckButton()
    {
        enemyDeckDetailsArea.SetActive(!enemyDeckDetailsArea.activeSelf);
    }

    public void RefreshPlayerDetails()
    {
        playerDeckList.InitDeckListObject(loadedDeck, _campaignManagerUI: this);
        honourPointsText.text = $"<b>Honour Points:</b> {loadedDeck.CampaignTracker.HonourPoints}";
    }

    public void AccessCamp()
    {

    }

    /// <summary>
    /// 
    /// Button click event for begining a gameplay session
    /// 
    /// </summary>
    public void PlayGame()
    {
        GameManager.instance.LoadGameplay(new DeckData[] { loadedDeck, selectedScenario.EnemyDeck }, selectedScenario.Map, selectedScenario.Id.Value);
    }
}
