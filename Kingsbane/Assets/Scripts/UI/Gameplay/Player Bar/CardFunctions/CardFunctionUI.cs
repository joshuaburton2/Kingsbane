using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using CategoryEnums;

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

    /// <summary>
    /// 
    /// Initialisses the card function area
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// Refreshes the UI Component
    /// 
    /// </summary>
    public void RefreshCardFunctionUI()
    {
        tutorDrawArea.gameObject.SetActive(false);

        selectedCardGeneration = CardGenerationTypes.None;
        generateCardArea.CardGenerationType = CardGenerationTypes.None;
        generateCardArea.gameObject.SetActive(false);
    }

    /// <summary>
    /// 
    /// Button click event for drawing a card
    /// 
    /// </summary>
    public void Draw()
    {
        Player.Draw();
        PlayerUIBar.RefreshPlayerBar();
    }

    /// <summary>
    /// 
    /// Button click event for opening the tutor draw area
    /// 
    /// </summary>
    public void OpenTutorDrawArea()
    {
        generateCardArea.gameObject.SetActive(false);
        tutorDrawArea.gameObject.SetActive(!tutorDrawArea.gameObject.activeSelf);

        if (tutorDrawArea.gameObject.activeSelf)
            tutorDrawArea.OpenTutorDrawArea();
    }

    /// <summary>
    /// 
    /// Function call from tutor draw area to confirm tutor draw
    /// 
    /// </summary>
    public bool TutorDraw(CardListFilter cardFilter, int? numToChoose = null)
    {
        var filterSuccess = Player.Draw(cardFilter, numToChoose);
        if (filterSuccess)
            PlayerUIBar.RefreshPlayerBar();
        return filterSuccess;
    }

    /// <summary>
    /// 
    /// Button click event for adding to hand
    /// 
    /// </summary>
    public void OpenAddToHandArea()
    {
        selectedCardGeneration = CardGenerationTypes.Hand;
        OpenCardGenerationArea();
    }

    /// <summary>
    /// 
    /// Button click event for adding to deck
    /// 
    /// </summary>
    public void OpenAddToDeckArea()
    {
        selectedCardGeneration = CardGenerationTypes.Deck;
        OpenCardGenerationArea();
    }

    /// <summary>
    /// 
    /// Button click event for adding to graveyard
    /// 
    /// </summary>
    public void OpenAddToGraveyardArea()
    {
        selectedCardGeneration = CardGenerationTypes.Graveyard;
        OpenCardGenerationArea();
    }

    /// <summary>
    /// 
    /// General case for opening card generation area
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// Function call for generate card area to confirm card generation
    /// 
    /// </summary>
    public bool ConfirmCardGeneration(GenerateCardFilter filter, bool isChoice, string createdBy, DeckPositions deckPositions = DeckPositions.Random)
    {
        var filterSuccess = Player.GenerateCards(filter, selectedCardGeneration, isChoice, createdBy, deckPositions);
        if (filterSuccess)
            PlayerUIBar.RefreshPlayerBar();
        return filterSuccess;
    }

    /// <summary>
    /// 
    /// Button click event for returning from discard pool
    /// 
    /// </summary>
    public void ReturnFromDiscard()
    {
        Player.ReturnFromDiscard();
        PlayerUIBar.RefreshPlayerBar();
    }
}
