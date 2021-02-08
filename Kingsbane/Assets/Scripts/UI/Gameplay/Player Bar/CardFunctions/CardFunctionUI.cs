using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFunctionUI : MonoBehaviour
{
    private Player Player { get; set; }
    public PlayerUIBar PlayerUIBar { get; set; }

    [Header("Tutor Draw Area")]
    private CardListFilter tutorDrawFilter;
    [SerializeField]
    private GameObject tutorDrawArea;

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

        tutorDrawArea.SetActive(false);
    }

    public void Draw()
    {
        Player.Draw();
        PlayerUIBar.RefreshPlayerBar();
    }

    public void OpenTutorDrawArea()
    {
        tutorDrawArea.SetActive(!tutorDrawArea.activeSelf);

        if (tutorDrawArea.activeSelf)
        {
            tutorDrawFilter = new CardListFilter();
        }
    }
}
