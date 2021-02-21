using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardFunctionUI : MonoBehaviour
{
    private Player Player { get; set; }
    public PlayerUIBar PlayerUIBar { get; set; }

    [Header("Tutor Draw Main Area")]
    
    [SerializeField]
    private TutorDrawUI tutorDrawArea;
    

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

        tutorDrawArea.InitTutorDraw(this);
        tutorDrawArea.gameObject.SetActive(false);
    }

    public void RefreshCardFunctionUI()
    {
        tutorDrawArea.gameObject.SetActive(false);
    }

    public void Draw()
    {
        Player.Draw();
        PlayerUIBar.RefreshPlayerBar();
    }

    public void OpenTutorDrawArea()
    {
        tutorDrawArea.gameObject.SetActive(!tutorDrawArea.gameObject.activeSelf);

        if (tutorDrawArea.gameObject.activeSelf)
        {
            tutorDrawArea.OpenTutorDrawArea();
        }
    }

    public bool TutorDraw(CardListFilter cardFilter)
    {
        var filterSuccess = Player.Draw(cardFilter);
        if (filterSuccess)
            PlayerUIBar.RefreshPlayerBar();
        return filterSuccess;
    }
}
