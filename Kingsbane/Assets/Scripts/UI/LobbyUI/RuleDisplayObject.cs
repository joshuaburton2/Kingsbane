using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

/// <summary>
/// 
/// Script for displaying rules in a scenario
/// 
/// </summary>
public class RuleDisplayObject : MonoBehaviour, IPointerClickHandler
{
    [NonSerialized]
    public Rule rule;
    private LobbyUI lobbyUI;
    private GameplayUI gameplayUI;

    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private GameObject descriptionArea;
    [SerializeField]
    private TextMeshProUGUI descriptionText;

    /// <summary>
    /// 
    /// Refreshes the display of the rule
    /// 
    /// </summary>
    public void RefreshRuleDisplay(Rule _rule, LobbyUI _lobbyUI = null, GameplayUI _gameplayUI = null)
    {
        rule = _rule;
        lobbyUI = _lobbyUI;
        gameplayUI = _gameplayUI;

        nameText.text = rule.Name;
        descriptionText.text = rule.Description;

        descriptionArea.SetActive(false);
    }

    /// <summary>
    /// 
    /// Click event for the rule display
    /// 
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //Shows or hides the description of the clicked on rule
            if (descriptionArea.activeSelf)
            {
                descriptionArea.SetActive(false);
                if (lobbyUI != null)
                    lobbyUI.RefreshRuleList();
                else if (gameplayUI != null)
                    gameplayUI.RefreshRuleList();
                else
                    throw new Exception("Object not initialised properly");

            }
            else
            {
                descriptionArea.SetActive(true);
                if (lobbyUI != null)
                    lobbyUI.RefreshRuleList(rule.Id);
                else if (gameplayUI != null)
                    gameplayUI.RefreshRuleList(rule.Id);
                else
                    throw new Exception("Object not initialised properly");
            }
        }
    }
}
