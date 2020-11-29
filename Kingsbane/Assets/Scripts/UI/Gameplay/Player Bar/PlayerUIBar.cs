using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIBar : MonoBehaviour
{
    public int id;
    private Player Player { get { return GameManager.instance.GetPlayer(id); } }

    [Header("Bar Controllers")]
    [SerializeField]
    private HandUI handUI;
    [SerializeField]
    private ResourceUI resourceUI;
    [SerializeField]
    private HeroUI heroUI;
    [SerializeField]
    private CardListsUI cardListsUI;

    public void InitialisePlayerBar()
    {
        handUI.DisplayUpgradeList(Player.Upgrades);
    }
}
