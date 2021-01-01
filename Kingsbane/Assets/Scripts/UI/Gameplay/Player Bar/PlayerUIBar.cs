using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIBar : MonoBehaviour
{
    public int Id { get; set; }
    private Player Player { get { return GameManager.instance.GetPlayer(Id); } }
    public bool IsActivePlayerBar { get { return Id == GameManager.instance.ActivePlayerId; } }

    [Header("Bar Controllers")]
    [SerializeField]
    private HandUI handUI;
    [SerializeField]
    private ResourceUI resourceUI;
    [SerializeField]
    private HeroUI heroUI;
    [SerializeField]
    private CardListsUI cardListsUI;

    public void InitialisePlayerBar(int _id)
    {
        Id = _id;

        handUI.DisplayHandList(Player.Upgrades, true);
        cardListsUI.InitCardLists(Player);
    }

    public void RefreshPlayerBar()
    {
        handUI.DisplayHandList(Player.Hand.cardList, IsActivePlayerBar);
        cardListsUI.RefreshCurrentList();
    }
}
