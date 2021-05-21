using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewDeckUI : MonoBehaviour
{
    private List<CardResources> selectedResources;
    public ClassData selectedClassData;
    private UnitData heroCard;
    List<DeckData> deckTemplates;
    DeckData selectedTemplate;

    [Header("Class Selection")]
    [SerializeField]
    GameObject classListParent;
    [SerializeField]
    GameObject classListPrefab;

    [Header("ResourceSelection")]
    [SerializeField]
    private List<ResourceList> resourceLists;

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
    [SerializeField]
    LoadCampaignUI loadCampaignUI;

    private int? campaignId;

    private void Start()
    {
        //Loop through each class and create a class list object- DEPRICATED. Leaving code here in case changing back
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
            tierOptions[i] = tierOptions[i].Replace($"{i}", $" {i}");
        }
        heroTierDropdown.AddOptions(tierOptions);
        abilityTierDropdown.AddOptions(tierOptions);
    }

    /// <summary>
    /// 
    /// Initialise the deck page on opening
    /// 
    /// </summary>
    public void InitNewDeckPage(int? _campaignId = null)
    {
        heroTierDropdown.value = 0;
        abilityTierDropdown.value = 0;
        deckTemplateDropdown.value = 0;

        //Initialises each resource list
        selectedResources = new List<CardResources>();
        foreach (var resourceList in resourceLists)
        {
            resourceList.InitResourceList();
        }

        campaignId = _campaignId;

        SelectClassData(Classes.ClassList.Default);
    }

    /// <summary>
    /// 
    /// Function call for selecting a resource from the list
    /// 
    /// </summary>
    /// <param name="toSelect">Boolean function to say if the resource is being selected or deselected</param>
    /// <param name="selectedResource">The resource which has been selected</param>
    /// <param name="resourceList">The resource list object which caused the click event</param>
    public void SelectResource(bool toSelect, CardResources selectedResource, ResourceList resourceList)
    {
        //If a resource is being selected, then add it to the list of selected resource
        if (toSelect)
        {
            selectedResources.Add(selectedResource);
            //If only one resource is selected, then removes the resource from the other list and sets up the class data as the default list
            if (selectedResources.Count == 1)
            {
                foreach (var list in resourceLists)
                    if (list != resourceList)
                        list.RefreshResourceList(selectedResource);
                SelectClassData(Classes.ClassList.Default);
            }
            //If both resources are selected, then selects the class based on the two resources selected
            else if (selectedResources.Count == 2)
                SelectClassData(selectedResources);
            else
                throw new Exception("Too many resource selected");
        }
        //If a resource is being deselected, then remove it from the list of selected resource
        else
        {
            selectedResources.Remove(selectedResource);
            //If there are no resources selected refresh all the lists with all resources and selects the default class
            if (selectedResources.Count == 0)
            {
                foreach (var list in resourceLists)
                    list.RefreshResourceList();
                SelectClassData(Classes.ClassList.Default);
            }
            //If there is only one resource selected, refreshes the list removed from, exempting the resource selected in the other list
            else if (selectedResources.Count == 1)
            {
                foreach (var list in resourceLists)
                    if (list == resourceList)
                        list.RefreshResourceList(selectedResources.FirstOrDefault());
                SelectClassData(Classes.ClassList.Default);
            }
            else
                throw new Exception("Too many resource selected");
        }
    }

    /// <summary>
    /// 
    /// Selects the class data and refreshes UI based on a given class
    /// 
    /// </summary>
    public void SelectClassData(Classes.ClassList selectedClass)
    {
        //Load in the selected class
        selectedClassData = Classes.GetClassData(selectedClass);

        RefreshClassData();
    }

    /// <summary>
    /// 
    /// Selects the class data and refreshes UI based on a given set of resources
    /// 
    /// </summary>
    public void SelectClassData(List<CardResources> selectedResources)
    {
        selectedClassData = Classes.GetClassData(selectedResources);

        RefreshClassData();
    }

    /// <summary>
    /// 
    /// Refresh the class information that pertains to the selected class
    /// 
    /// </summary>
    private void RefreshClassData()
    {
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
            deckTemplates = GameManager.instance.deckManager.GetPlayerDeckTemplates(selectedClassData.ThisClass);
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
        GameManager.DestroyAllChildren(heroCardArea);

        //If card area is empty if the class is the default class
        if (selectedClassData.ThisClass != Classes.ClassList.Default)
        {
            //Get the input tier values for the hero
            var heroTier = (TierLevel)heroTierDropdown.value;
            var abilityTier = (TierLevel)abilityTierDropdown.value;

            //Gets the hero card and create the card object
            heroCard = GameManager.instance.libraryManager.GetHero(selectedClassData.ThisClass, heroTier, abilityTier);
            var heroCardObject = GameManager.instance.libraryManager.CreateCardObject(heroCard, heroCardArea.transform);
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
        if (campaignId.HasValue)
        {
            var newDeck = GameManager.instance.deckManager.CreatePlayerDeck(selectedTemplate, deckNameInput.text, campaignId);
            loadCampaignUI.LoadCampaignDeck(newDeck);
            campaignId = null;
        }
        else
        {
            GameManager.instance.deckManager.CreatePlayerDeck(selectedTemplate, deckNameInput.text);
            deckList.RefreshDeckList();
        }

        GameManager.instance.uiManager.ClosePanel(gameObject);
    }
}
