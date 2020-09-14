using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewDeckUI : MonoBehaviour
{
    public ClassData selectedClassData;
    private UnitData heroCard;
    List<DeckData> deckTemplates;
    DeckData selectedTemplate;

    [SerializeField]
    GameObject classListParent;
    [SerializeField]
    GameObject classListPrefab;

    [Header("Class Details Fields")]
    [SerializeField]
    TextMeshProUGUI classNameText;
    [SerializeField]
    GameObject heroCardArea;
    [SerializeField]
    TextMeshProUGUI dominantResourceText;
    [SerializeField]
    TextMeshProUGUI secondaryResourceText;
    [SerializeField]
    TextMeshProUGUI playstyleText;
    [SerializeField]
    TextMeshProUGUI strengthText;
    [SerializeField]
    TextMeshProUGUI weaknessText;
    [SerializeField]
    TextMeshProUGUI descriptionText;

    [Header("Deck Choice Dropdowns")]
    [SerializeField]
    TMP_Dropdown heroTierDropdown;
    [SerializeField]
    TMP_Dropdown abilityTierDropdown;
    [SerializeField]
    TMP_Dropdown deckTemplateDropdown;

    [Header("Card List Fields")]
    [SerializeField]
    TextMeshProUGUI deckNameText;
    [SerializeField]
    DeckCardListUI deckCardList;
    [SerializeField]
    TMP_InputField deckNameInput;
    [SerializeField]
    Button createDeckButton;

    [Header("Other Objects")]
    [SerializeField]
    DeckListUI deckList;

    private void Start()
    {
        foreach (var newClass in Enum.GetValues(typeof(Classes.ClassList)).Cast<Classes.ClassList>())
        {
            if (newClass != Classes.ClassList.Default)
            {
                var classListObject = Instantiate(classListPrefab, classListParent.transform);
                classListObject.GetComponent<ClassListObject>().InitClassListObject(newClass, this);
                classListObject.name = $"Class: {newClass}";
            }
        }

        var tierOptions = Enum.GetNames(typeof(TierLevel)).ToList();

        for (int i = 0; i < tierOptions.Count; i++)
        {
            tierOptions[i] = tierOptions[i].Replace($"{i+1}", $" {i+1}");
        }

        heroTierDropdown.AddOptions(tierOptions);
        abilityTierDropdown.AddOptions(tierOptions);
    }

    public void InitNewDeckPage()
    {
        RefreshClassData(Classes.ClassList.Default);
    }

    public void RefreshClassData(Classes.ClassList selectedClass)
    {
        selectedClassData = Classes.GetClassData(selectedClass);
        deckTemplateDropdown.options.Clear();

        playstyleText.text = selectedClassData.GetStringData(ClassData.ClassDataFields.Playstyle);
        strengthText.text = selectedClassData.GetStringData(ClassData.ClassDataFields.Strengths);
        weaknessText.text = selectedClassData.GetStringData(ClassData.ClassDataFields.Weaknesses);
        descriptionText.text = selectedClassData.GetStringData(ClassData.ClassDataFields.Description);

        deckTemplateDropdown.value = 0;

        ResetHeroCard();
        deckCardList.RefreshCardList();

        if (selectedClassData.ThisClass == Classes.ClassList.Default)
        {
            classNameText.text = "-";
            dominantResourceText.text = "-";
            secondaryResourceText.text = "-";
            deckNameText.text = "-";

            heroTierDropdown.interactable = false;
            abilityTierDropdown.interactable = false;
            deckTemplateDropdown.interactable = false;

            deckTemplateDropdown.AddOptions(new List<string>() { "None", });
        }
        else
        {
            classNameText.text = selectedClassData.ClassName;
            dominantResourceText.text = selectedClassData.GetResourceOfType(ClassResourceType.ResourceTypes.Dominant).ToString();
            secondaryResourceText.text = selectedClassData.GetResourceOfType(ClassResourceType.ResourceTypes.Secondary).ToString();

            heroTierDropdown.interactable = true;
            abilityTierDropdown.interactable = true;
            deckTemplateDropdown.interactable = true;

            deckTemplates = GameManager.instance.deckManager.GetPlayerDeckTemplates(selectedClass);
            foreach (var deck in deckTemplates)
            {
                deckTemplateDropdown.AddOptions(new List<string>() { deck.Name, });
            }
            ChangeDeckTemplate();
        }

        if (selectedClassData.IsPlayable)
        {
            deckNameInput.text = $"New {selectedClassData.ClassName} Deck";
            deckNameInput.interactable = true;
            createDeckButton.interactable = true;
        }
        else
        {
            deckNameInput.text = "";
            deckNameInput.interactable = false;
            createDeckButton.interactable = false;
        }
    }

    public void ResetHeroCard()
    {
        foreach (Transform child in heroCardArea.transform)
        {
            Destroy(child.gameObject);
        }

        if (selectedClassData.ThisClass != Classes.ClassList.Default)
        {
            var heroTier = (TierLevel)heroTierDropdown.value;
            var abilityTier = (TierLevel)abilityTierDropdown.value;

            heroCard = GameManager.instance.libraryManager.GetHero(selectedClassData.ThisClass, heroTier, abilityTier);
            var heroCardObject = GameManager.instance.libraryManager.CreateCard(heroCard, heroCardArea.transform);

            heroCardObject.name = $"Hero Card: {heroCard.Name}";

            if (selectedTemplate != null)
            {
                ChangeDeckTemplate();
            }
        }
    }

    public void ChangeDeckTemplate()
    {
        if (selectedClassData.ThisClass != Classes.ClassList.Default)
        {
            selectedTemplate = new DeckData(deckTemplates[deckTemplateDropdown.value]);
            deckNameText.text = selectedTemplate.Name;
            selectedTemplate.AddCard(heroCard);

            deckCardList.RefreshCardList(selectedTemplate);
        }
    }

    public void CreateNewDeck()
    {
        GameManager.instance.deckManager.CreatePlayerDeck(selectedTemplate, deckNameInput.text);
        deckList.RefreshDeckList();
        GameManager.instance.uiManager.ClosePanel(gameObject);
    }
}
