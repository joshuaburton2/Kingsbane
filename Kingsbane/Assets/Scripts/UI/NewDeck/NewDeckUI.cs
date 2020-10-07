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
        //Loop through each class and create a class list object
        foreach (var newClass in Enum.GetValues(typeof(Classes.ClassList)).Cast<Classes.ClassList>())
        {
            //Ignore the default class
            if (newClass != Classes.ClassList.Default)
            {
                var classListObject = Instantiate(classListPrefab, classListParent.transform);
                classListObject.GetComponent<ClassListObject>().InitClassListObject(newClass, this);
                classListObject.name = $"Class: {newClass}";
            }
        }

        //Create the tier options string list then add them into dropdowns
        var tierOptions = Enum.GetNames(typeof(TierLevel)).Where(x => x != TierLevel.Default.ToString()).ToList();
        for (int i = 0; i < tierOptions.Count; i++)
        {
            tierOptions[i] = tierOptions[i].Replace($"{i+1}", $" {i+1}");
        }
        heroTierDropdown.AddOptions(tierOptions);
        abilityTierDropdown.AddOptions(tierOptions);
    }

    /// <summary>
    /// 
    /// Initialise the deck page on opening
    /// 
    /// </summary>
    public void InitNewDeckPage()
    {
        RefreshClassData(Classes.ClassList.Default);
    }

    /// <summary>
    /// 
    /// Refresh the class information that pertains to the selected class
    /// 
    /// </summary>
    /// <param name="selectedClass"></param>
    public void RefreshClassData(Classes.ClassList selectedClass)
    {
        //Load in the selected class
        selectedClassData = Classes.GetClassData(selectedClass);
        //Clears the deck template dropdown of options
        deckTemplateDropdown.options.Clear();
        //Set the value of the deck template dropdown to the initial value
        deckTemplateDropdown.value = 0;

        //Load the class data text fields
        playstyleText.text = selectedClassData.GetStringData(ClassData.ClassDataFields.Playstyle);
        strengthText.text = selectedClassData.GetStringData(ClassData.ClassDataFields.Strengths);
        weaknessText.text = selectedClassData.GetStringData(ClassData.ClassDataFields.Weaknesses);
        descriptionText.text = selectedClassData.GetStringData(ClassData.ClassDataFields.Description);

        //Display the hero card and update the card list
        ResetHeroCard();
        deckCardList.RefreshCardList();

        //Case if the deck is the default class, should only occur when the page opens for the first time
        if (selectedClassData.ThisClass == Classes.ClassList.Default)
        {
            //Set the properties of the default state of the UI
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
            //Set the properties of the selected class
            classNameText.text = selectedClassData.ClassName;
            dominantResourceText.text = selectedClassData.GetResourceOfType(ClassResourceType.ResourceTypes.Dominant).ToString();
            secondaryResourceText.text = selectedClassData.GetResourceOfType(ClassResourceType.ResourceTypes.Secondary).ToString();

            heroTierDropdown.interactable = true;
            abilityTierDropdown.interactable = true;
            deckTemplateDropdown.interactable = true;

            //Load the deck templates of the 
            deckTemplates = GameManager.instance.deckManager.GetPlayerDeckTemplates(selectedClass);
            foreach (var deck in deckTemplates)
            {
                deckTemplateDropdown.AddOptions(new List<string>() { deck.Name, });
            }
            ChangeDeckTemplate();
        }

        //Set the properties of the class depeneding on if the class is playable or not
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

    /// <summary>
    /// 
    /// Resets the properties of the hero card
    /// 
    /// </summary>
    public void ResetHeroCard()
    {
        //Destroy any previous hero cards
        GameManager.DestroyAllChildren(heroCardArea.transform);

        //If card area is empty if the class is the default class
        if (selectedClassData.ThisClass != Classes.ClassList.Default)
        {
            //Get the input tier values for the hero
            var heroTier = (TierLevel)heroTierDropdown.value;
            var abilityTier = (TierLevel)abilityTierDropdown.value;

            //Gets the hero card and create the card object
            heroCard = GameManager.instance.libraryManager.GetHero(selectedClassData.ThisClass, heroTier, abilityTier);
            var heroCardObject = GameManager.instance.libraryManager.CreateCard(heroCard, heroCardArea.transform);
            heroCardObject.name = $"Hero Card: {heroCard.Name}";

            //Updates the deck template if there is a deck present
            if (selectedTemplate != null)
            {
                ChangeDeckTemplate();
            }
        }
    }

    /// <summary>
    /// 
    /// Update the deck card list with the selected deck template and hero card
    /// 
    /// </summary>
    public void ChangeDeckTemplate()
    {
        //Only active if the selected class is not the default one
        if (selectedClassData.ThisClass != Classes.ClassList.Default)
        {
            //Update the properties of the selected deck template and refresh the card list
            selectedTemplate = new DeckData(deckTemplates[deckTemplateDropdown.value]);
            selectedTemplate.UpdateHeroCard((TierLevel)heroTierDropdown.value, (TierLevel)abilityTierDropdown.value);
            deckNameText.text = selectedTemplate.Name;
            deckCardList.RefreshCardList(selectedTemplate, deckList);
        }
    }

    /// <summary>
    /// 
    /// Button click event to create a new deck
    /// 
    /// </summary>
    public void CreateNewDeck()
    {
        GameManager.instance.deckManager.CreatePlayerDeck(selectedTemplate, deckNameInput.text);
        deckList.RefreshDeckList();
        GameManager.instance.uiManager.ClosePanel(gameObject);
    }
}
