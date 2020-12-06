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
    private GameObject cardDisplayParent;
    [SerializeField]
    private TextMeshProUGUI actionButtonText;

    public void InitialiseUI()
    {
        cardDisplayArea.SetActive(false);

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
        switch (GameManager.instance.CurrentGamePhase)
        {
            case GameManager.GamePhases.Menu:
                break;
            case GameManager.GamePhases.Setup:
                GameManager.instance.StartGame();
                SetPlayerTurnText();

                ShowCardDisplay(GameManager.instance.GetActivePlayer().Hero);
                break;
            case GameManager.GamePhases.HeroDeploy:
                break;
            case GameManager.GamePhases.Mulligan:
                break;
            case GameManager.GamePhases.Gameplay:
                break;
            case GameManager.GamePhases.End:
                break;
            default:
                break;
        }
    }

    private void SetPlayerTurnText()
    {
        actionButtonText.text = $"End Turn <size=60%>(Player: {GameManager.instance.ActivePlayerId})";
    }

    public void ShowCardDisplay(Card card)
    {
        cardDisplayArea.SetActive(true);
        GameManager.DestroyAllChildren(cardDisplayParent);
        GameManager.instance.libraryManager.CreateCardObject(card, cardDisplayParent.transform, 0.25f);
    }
}