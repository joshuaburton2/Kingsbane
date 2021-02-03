using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFunctionUI : MonoBehaviour
{
    private Player Player { get; set; }
    public PlayerUIBar PlayerUIBar { get; set; }

    [SerializeField]
    private CanvasGroup buttonGroup;

    private void Update()
    {
        if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
            buttonGroup.interactable = !GameManager.instance.effectManager.IsUILocked;
    }

    public void InitCardFunctionUI(Player player, PlayerUIBar playerUIBar)
    {
        Player = player;
        PlayerUIBar = playerUIBar;

        buttonGroup.interactable = false;
    }

    public void Draw()
    {
        Player.Draw();
        PlayerUIBar.RefreshPlayerBar();
    }
}
