using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardFunctionUI : MonoBehaviour
{


    private Player Player { get; set; }
    public PlayerUIBar PlayerUIBar { get; set; }


    [SerializeField]
    private CanvasGroup buttonGroup;

    [Header("Tutor Card Area")]
    [SerializeField]
    private TutorDrawUI tutorDrawArea;

    [Header("Generate Card Area")]
    [SerializeField]
    private GenerateCardUI generateCardArea;
    private CardGenerationTypes selectedCardGeneration;

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

        generateCardArea.InitGenerateCard(this, player.PlayerClass);
        generateCardArea.gameObject.SetActive(false);
    }

    public void RefreshCardFunctionUI()
    {
        tutorDrawArea.gameObject.SetActive(false);

        selectedCardGeneration = CardGenerationTypes.None;
        generateCardArea.CardGenerationType = CardGenerationTypes.None;
        generateCardArea.gameObject.SetActive(false);
    }

    public void Draw()
    {
        Player.Draw();
        PlayerUIBar.RefreshPlayerBar();
    }

    public void OpenTutorDrawArea()
    {
        generateCardArea.gameObject.SetActive(false);
        tutorDrawArea.gameObject.SetActive(!tutorDrawArea.gameObject.activeSelf);

        if (tutorDrawArea.gameObject.activeSelf)
            tutorDrawArea.OpenTutorDrawArea();
    }

    public bool TutorDraw(CardListFilter cardFilter)
    {
        var filterSuccess = Player.Draw(cardFilter);
        if (filterSuccess)
            PlayerUIBar.RefreshPlayerBar();
        return filterSuccess;
    }

    public void OpenAddToHandArea()
    {
        selectedCardGeneration = CardGenerationTypes.Hand;
        OpenCardGenerationArea();
    }

    public void OpenAddToDeckArea()
    {
        selectedCardGeneration = CardGenerationTypes.Deck;
        OpenCardGenerationArea();
    }

    public void OpenAddToGraveyardArea()
    {
        selectedCardGeneration = CardGenerationTypes.Graveyard;
        OpenCardGenerationArea();
    }

    private void OpenCardGenerationArea()
    {
        tutorDrawArea.gameObject.SetActive(false);
        if (selectedCardGeneration != generateCardArea.CardGenerationType)
        {
            generateCardArea.gameObject.SetActive(true);
            generateCardArea.OpenGenerateCardArea(selectedCardGeneration);
        }
        else
        {
            generateCardArea.gameObject.SetActive(!generateCardArea.gameObject.activeSelf);
            if (generateCardArea.gameObject.activeSelf)
                generateCardArea.OpenGenerateCardArea(selectedCardGeneration);
            else
            {
                selectedCardGeneration = CardGenerationTypes.None;
                generateCardArea.CardGenerationType = CardGenerationTypes.None;
            }
        }
    }

    public bool ConfirmCardGeneration(GenerateCardFilter filter, DeckPositions deckPositions = DeckPositions.Random)
    {
        var filterSuccess = Player.GenerateCards(filter, selectedCardGeneration, deckPositions);
        if (filterSuccess)
            PlayerUIBar.RefreshPlayerBar();
        return filterSuccess;
    }

    public void ReturnFromDiscard()
    {
        Player.ReturnFromDiscard();
        PlayerUIBar.RefreshPlayerBar();
    }
}
