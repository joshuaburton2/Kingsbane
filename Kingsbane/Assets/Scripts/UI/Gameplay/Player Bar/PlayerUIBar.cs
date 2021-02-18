using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private GameplayUI gameplayUI;

    public void InitialisePlayerBar(int _id)
    {
        Id = _id;

        handUI.DisplayHandList(gameplayUI, Player.Upgrades, true, Id);
        cardListsUI.InitCardLists(Player);
        resourceUI.InitResourceUI(Player.Resources, this);
        heroUI.InitHeroUI(Player.Hero);
        cardFunctionUI.InitCardFunctionUI(Player, this);

        unitCommandUI.gameObject.SetActive(false);

        turnIndicator.SetActive(false);

        cardListsUI.gameObject.SetActive(false);
    }

    public void RefreshPlayerBar()
    {
        UpdateTurnIndicator();

        handUI.DisplayHandList(gameplayUI, Player.Hand.cardList, IsActivePlayerBar, Id);
        cardListsUI.RefreshCurrentList();
        resourceUI.RefreshResourceUI();
        heroUI.RefreshHeroUI();
        cardFunctionUI.RefreshCardFunctionUI();

        cardListsUI.gameObject.SetActive(false);
    }

    public void UpdateTurnIndicator()
    {
        if (IsActivePlayerBar)
        {
            if (GameManager.instance.effectManager.ActiveEffect != ActiveEffectTypes.UnitCommand)
            {
                unitCommandUI.gameObject.SetActive(false);
            }
            else
            {
                unitCommandUI.RefreshCommandBar();
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
}
