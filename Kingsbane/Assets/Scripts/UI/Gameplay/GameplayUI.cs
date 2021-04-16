﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    [SerializeField]
    private EffectsBarUI effectBarUI;
    [SerializeField]
    private List<PlayerUIBar> playerUIBars;
    [SerializeField]
    private GameObject menuPopup;

    [Header("Miscellaneous Area")]
    [SerializeField]
    private GameObject cardDisplayArea;
    [SerializeField]
    private GameObject cardDisplayParent;
    [SerializeField]
    private CanvasGroup miscCanvasGroup;
    [SerializeField]
    private Button actionButton;
    [SerializeField]
    private TextMeshProUGUI actionButtonText;
    [SerializeField]
    private Button mapKeyButton;
    [SerializeField]
    private GameObject keyDisplay;
    [SerializeField]
    private MapKeyUI mapKey;

    [Header("Player Choice Displays")]
    [SerializeField]
    private GameObject backgroundFade;
    [SerializeField]
    private CardChoiceUI cardChoiceUI;
    [SerializeField]
    private DivinateUI divinateUI;
    [SerializeField]
    private AlterFateUI alterFateUI;

    [Header("RNG Display")]
    [SerializeField]
    private GameObject rngDisplay;
    [SerializeField]
    private TMP_InputField maxValueInput;
    [SerializeField]
    private TextMeshProUGUI rollValueText;

    private MapGrid.MapFilters CurrentMapFilter { get; set; }

    public void Update()
    {
        //miscCanvasGroup.interactable = !GameManager.instance.effectManager.IsUILocked;
        actionButton.interactable = !GameManager.instance.effectManager.IsUILocked;
        mapKeyButton.interactable = !GameManager.instance.effectManager.IsUILocked;

        if (Input.GetMouseButtonDown(1))
        {
            if (GameManager.instance.uiManager.OverGameplayArea)
            {
                CancelEffects();
                ShowKeyOfFilter();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPopup.SetActive(!menuPopup.activeSelf);
        }
    }

    public void CancelEffects()
    {
        //if (GameManager.instance.effectManager.ActiveEffect == EffectManager.ActiveEffectTypes.UnitCommand)
        //{
            SetSelectedCommandUnit();
        //}

        GameManager.instance.effectManager.CancelEffectManager();
    }

    public void InitialiseUI()
    {
        cardDisplayArea.SetActive(false);
        menuPopup.SetActive(false);
        cardChoiceUI.gameObject.SetActive(false);
        divinateUI.gameObject.SetActive(false);
        alterFateUI.gameObject.SetActive(false);
        backgroundFade.SetActive(false);
        keyDisplay.SetActive(false);
        rngDisplay.SetActive(false);

        CurrentMapFilter = MapGrid.MapFilters.Terrain;

        var counter = 0;
        foreach (var playerBar in playerUIBars)
        {
            playerBar.InitialisePlayerBar(counter);
            counter++;
        }

        actionButtonText.text = "Start Game";

        effectBarUI.RefreshEffectList();
    }

    public void ActionButton()
    {
        EndTurn();
    }

    public void EndTurn()
    {
        var isNewRound = false;

        switch (GameManager.instance.CurrentGamePhase)
        {
            case GameManager.GamePhases.Menu:
                break;
            case GameManager.GamePhases.Setup:
                GameManager.instance.CurrentGamePhase = GameManager.GamePhases.HeroDeploy;
                SetPlayerTurnText();

                RefreshHeroDeployUI();

                break;
            case GameManager.GamePhases.HeroDeploy:
                isNewRound = GameManager.instance.NextPlayerTurn();
                SetPlayerTurnText();

                if (isNewRound)
                {
                    ShowCardDisplay();
                    RefreshPlayerBar();
                }
                else
                {
                    RefreshHeroDeployUI();
                }
                break;
            case GameManager.GamePhases.Mulligan:
                isNewRound = GameManager.instance.NextPlayerTurn();
                SetPlayerTurnText();

                if (isNewRound)
                {
                    RefreshPlayerBar();
                }
                else
                {
                    RefreshPlayerBar();
                }
                break;
            case GameManager.GamePhases.Gameplay:
                isNewRound = GameManager.instance.NextPlayerTurn();
                SetPlayerTurnText();

                RefreshPlayerBar();

                break;
            case GameManager.GamePhases.End:
                break;
            default:
                throw new Exception("Not a valid game phase");
        }

        effectBarUI.RefreshEffectList();
        ShowCardDisplay();
    }

    private void RefreshHeroDeployUI()
    {
        foreach (var playerBar in playerUIBars)
            playerBar.UpdateTurnIndicator();
        ShowCardDisplay(GameManager.instance.GetPlayer().Hero);
    }

    private void SetPlayerTurnText()
    {
        actionButtonText.text = $"End Turn <size=60%>(Player: {GameManager.instance.ActivePlayerId})";
    }

    public void SetActionButtonState(bool state)
    {
        actionButton.interactable = state;
    }

    public void MenuButton()
    {
        menuPopup.SetActive(true);
    }

    public void ShowCardDisplay(Card card = null)
    {
        if (card != null)
        {
            cardDisplayArea.SetActive(true);
            GameManager.DestroyAllChildren(cardDisplayParent);
            GameManager.instance.libraryManager.CreateCardObject(card, cardDisplayParent.transform, 0.25f);
        }
        else
        {
            cardDisplayArea.SetActive(false);
        }
    }

    public void RefreshPlayerBar(int? id = null)
    {
        backgroundFade.SetActive(false);
        if (id == null)
        {
            foreach (var playerBar in playerUIBars)
            {
                playerBar.RefreshPlayerBar();
            }

            ShowCardDisplay();
        }
        else
        {
            playerUIBars[id.Value].RefreshPlayerBar();
        }
    }

    public void RefreshHeroStats(int id, Unit overrideUnit)
    {
        playerUIBars[id].RefreshHeroStats(overrideUnit);
    }

    public void SetSelectedCommandUnit(Unit unit = null)
    {
        playerUIBars[GameManager.instance.ActivePlayerId.Value].SetSelectedCommandUnit(unit);
        ShowCardDisplay(unit);
    }

    public void ShowCardChoice(List<Card> cards)
    {
        cardChoiceUI.gameObject.SetActive(true);
        cardChoiceUI.DisplayCardChoice(cards);
    }

    public void ShowDivinate(List<Card> cards)
    {
        divinateUI.gameObject.SetActive(true);
        divinateUI.DisplayDivinate(cards);
    }

    public void ShowAlterFate(List<Card> handCards, List<Card> deckCards)
    {
        alterFateUI.gameObject.SetActive(true);
        alterFateUI.DisplayAlterFate(handCards, deckCards);
    }

    public void ShowKeyOfFilter(MapGrid.MapFilters mapFilter = MapGrid.MapFilters.Colour)
    {
        if (mapFilter == MapGrid.MapFilters.Colour)
        {
            keyDisplay.SetActive(false);
            GameManager.instance.mapGrid.SwitchMapFilter(mapFilter);
        }
        else
        {
            keyDisplay.SetActive(true);
            mapKey.ChangeMapFilter((int)mapFilter);
        }

    }

    public void ShowMapKey()
    {
        keyDisplay.SetActive(!keyDisplay.activeSelf);

        if (keyDisplay.activeSelf)
        {
            mapKey.ChangeMapFilter((int)CurrentMapFilter);
        }
        else
        {
            CurrentMapFilter = mapKey.CurrentFilter;
            GameManager.instance.mapGrid.SwitchMapFilter(MapGrid.MapFilters.Colour);
        }
    }

    public void ShowRNGDisplay()
    {
        rngDisplay.SetActive(!rngDisplay.activeSelf);

        if (rngDisplay.activeSelf)
        {
            maxValueInput.text = "";
            rollValueText.text = "-";
        }
    }

    public void rngRoll()
    {
        if (int.TryParse(maxValueInput.text, out int maxValue))
        {
            if (maxValue > 0)
            {
                var rollResult = UnityEngine.Random.Range(1, maxValue + 1);
                rollValueText.text = rollResult.ToString();
            }
            else
            {
                maxValueInput.text = "";
                rollValueText.text = "-";
            }
        }
        else
        {
            maxValueInput.text = "";
            rollValueText.text = "-";
        }
    }
}