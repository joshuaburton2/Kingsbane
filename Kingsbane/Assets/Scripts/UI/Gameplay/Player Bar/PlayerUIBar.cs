using CategoryEnums;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static EffectManager;

public class PlayerUIBar : MonoBehaviour
{
    public int Id { get; set; }
    private Player Player { get { return GameManager.instance.GetPlayer(Id); } }
    public bool IsActivePlayerBar { get { return Player.IsActivePlayer; } }

    [SerializeField]
    private GameObject turnIndicator;
    [Header("Bar Controllers")]
    [SerializeField]
    private HandUI handUI;
    [SerializeField]
    private ResourceUI resourceUI;
    [SerializeField]
    private HeroUI heroUI;
    [SerializeField]
    private CardListsUI cardListsUI;
    [SerializeField]
    private CardFunctionUI cardFunctionUI;
    [SerializeField]
    private UnitCommandUI unitCommandUI;
    [SerializeField]
    private VictoryStateUI victoryStateUI;
    [SerializeField]
    private CanvasGroup lossStateArea;
    [SerializeField]
    private Button bonusObjectiveButton;
    [SerializeField]
    private GameplayUI gameplayUI;

    private void Update()
    {
        lossStateArea.interactable = !GameManager.instance.effectManager.IsUILocked;
    }

    public void InitialisePlayerBar(int _id)
    {
        Id = _id;

        ShowUpgradesInHand();
        cardListsUI.InitCardLists(Player);
        resourceUI.InitResourceUI(Player.Resources, this);
        heroUI.InitHeroUI(Player.Hero);
        cardFunctionUI.InitCardFunctionUI(Player, this);
        victoryStateUI.InitVictoryStateUI();

        unitCommandUI.gameObject.SetActive(false);
        victoryStateUI.gameObject.SetActive(false);

        turnIndicator.SetActive(false);

        cardListsUI.gameObject.SetActive(false);

        bonusObjectiveButton.interactable = !Player.DeckData.IsNPCDeck && Player.DeckData.IsCampaign;
    }

    public void RefreshPlayerBar()
    {
        UpdateTurnIndicator();

        switch (GameManager.instance.CurrentGamePhase)
        {
            case GameManager.GamePhases.Setup:
                ShowUpgradesInHand();
                break;
            default:
                if (Player.RedeployUnits.Count == 0 || !IsActivePlayerBar)
                {
                    handUI.DisplayHandList(gameplayUI, Player.Hand.cardList, IsActivePlayerBar, Id);
                    gameplayUI.SetActionButtonState(true);
                }
                else
                {
                    handUI.DisplayHandList(gameplayUI, Player.RedeployUnits, IsActivePlayerBar, Id, true);
                    gameplayUI.SetActionButtonState(false);
                }
                break;
        }

        cardListsUI.RefreshCurrentList();
        resourceUI.RefreshResourceUI();
        heroUI.RefreshHeroUI();
        cardFunctionUI.RefreshCardFunctionUI();

        cardListsUI.gameObject.SetActive(false);
    }

    public void RefreshHeroStats(Unit overrideUnit)
    {
        if (overrideUnit == null)
            heroUI.RefreshHeroUI();
        else
            heroUI.OverrideHero(overrideUnit);
    }

    private void ShowUpgradesInHand()
    {
        var upgradeList = Player.Upgrades.Where(x => !x.IsRepeatable).ToList();
        if (Player.DeathDefiant)
            upgradeList.Add(Player.Upgrades.FirstOrDefault(x => x.UpgradeTag == UpgradeTags.DeathDefiant));
        handUI.DisplayHandList(gameplayUI, upgradeList, true, Id);
    }

    public void UpdateTurnIndicator()
    {
        if (IsActivePlayerBar)
        {
            if (GameManager.instance.effectManager.ActiveEffect == ActiveEffectTypes.UnitCommand ||
                GameManager.instance.effectManager.ActiveEffect == ActiveEffectTypes.UnitUseSpeed ||
                GameManager.instance.effectManager.ActiveEffect == ActiveEffectTypes.UnitUseDisengageSpeed)
            {
                unitCommandUI.gameObject.SetActive(true);
                unitCommandUI.RefreshCommandBar();
            }
            else
            {
                unitCommandUI.gameObject.SetActive(false);
            }
        }
        else
        {
            unitCommandUI.gameObject.SetActive(false);
        }
        cardListsUI.gameObject.SetActive(false);
        turnIndicator.SetActive(IsActivePlayerBar);
    }

    public void SetCardListOpen()
    {
        cardListsUI.gameObject.SetActive(!cardListsUI.gameObject.activeSelf);
    }

    public void SetSelectedCommandUnit(Unit unit = null)
    {
        if (unit != null)
        {
            unitCommandUI.gameObject.SetActive(true);
            unitCommandUI.SetCommandUnit(unit);
            handUI.MinimiseAllCards();
        }
        else
        {
            unitCommandUI.gameObject.SetActive(false);
        }
    }

    public void ShowVictoryUI(bool isVictory)
    {
        victoryStateUI.gameObject.SetActive(true);
        victoryStateUI.ShowVictoryState(isVictory);
    }

    public void TriggerLoss()
    {
        GameManager.instance.TriggerVictory(Player.Id);
    }

    public void CompleteBonusObjective()
    {
        Player.CompletedBonusObjective = true;
        bonusObjectiveButton.interactable = false;
    }
}
