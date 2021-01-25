using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EffectManager;

public class PlayerUIBar : MonoBehaviour
{
    public int Id { get; set; }
    private Player Player { get { return GameManager.instance.GetPlayer(Id); } }
    public bool IsActivePlayerBar { get { return Id == GameManager.instance.ActivePlayerId; } }

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
    private GameplayUI gameplayUI;

    public void InitialisePlayerBar(int _id)
    {
        Id = _id;

        handUI.DisplayHandList(gameplayUI, Player.Upgrades, true, Id);
        cardListsUI.InitCardLists(Player);
        resourceUI.InitResourceUI(Player.Resources, this);
        heroUI.InitHeroUI(Player.Hero);

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

        cardListsUI.gameObject.SetActive(false);
    }

    public void UpdateTurnIndicator()
    {
        cardListsUI.gameObject.SetActive(false);
        turnIndicator.SetActive(IsActivePlayerBar);
    }

    public void SetCardListOpen()
    {
        cardListsUI.gameObject.SetActive(!cardListsUI.gameObject.activeSelf);
    }
}
