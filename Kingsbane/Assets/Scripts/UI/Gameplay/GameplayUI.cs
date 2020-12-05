using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    [SerializeField]
    private List<PlayerUIBar> playerUIBars;

    [Header("Miscellaneous Area")]
    [SerializeField]
    private GameObject cardDisplayArea;
    [SerializeField]
    private TextMeshProUGUI actionButtonText;

    public void InitialiseUI()
    {
        var counter = 0;
        foreach (var playerBar in playerUIBars)
        {
            playerBar.InitialisePlayerBar(counter);
            counter++;
        }

        actionButtonText.text = "Start Game";
    }

    public void ActionButton()
    {
        if (GameManager.instance.GameStarted)
        {

        }
        else
        {
            GameManager.instance.StartGame();
            SetPlayerTurnText();

            ShowCardDisplay(GameManager.instance.GetActivePlayer().Hero);
        }
    }

    private void SetPlayerTurnText()
    {
        actionButtonText.text = $"End Turn <size=60%>(Player: {GameManager.instance.ActivePlayerId})";
    }

    public void ShowCardDisplay(Card card)
    {
        GameManager.DestroyAllChildren(cardDisplayArea);
        GameManager.instance.libraryManager.CreateCardObject(card, cardDisplayArea.transform, 0.25f);
    }
}