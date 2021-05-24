using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScenarioListObject : MonoBehaviour, IPointerClickHandler
{
    CampaignManagerUI campaignManagerUI;
    public Scenario scenario;

    [SerializeField]
    private TextMeshProUGUI indexText;
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    public GameObject selectScenarioBorder;

    public void InitScenarioListObject(CampaignManagerUI _campaignManagerUI, int index, Scenario _scenario)
    {
        campaignManagerUI = _campaignManagerUI;
        scenario = _scenario;

        indexText.text = index.ToString();
        nameText.text = scenario.Name;

        selectScenarioBorder.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            campaignManagerUI.SelectScenario(scenario);
        }
    }
}
