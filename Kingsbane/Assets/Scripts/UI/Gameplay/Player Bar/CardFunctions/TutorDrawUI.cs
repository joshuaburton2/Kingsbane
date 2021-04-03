using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorDrawUI : MonoBehaviour
{
    [Header("Generic Fields")]
    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private TMP_InputField nameInput;
    [SerializeField]
    private TMP_Dropdown rarityDropdown;
    [SerializeField]
    private TMP_Dropdown classDropdown;
    [SerializeField]
    private TMP_Dropdown tagDropdown;
    [SerializeField]
    private TMP_Dropdown resourceDropdown;
    [SerializeField]
    private Toggle isCreatedToggle;
    [SerializeField]
    private Toggle isChoiceToggle;
    [SerializeField]
    private TMP_InputField isChoiceNumberInput;
    [SerializeField]
    private TMP_Dropdown costFilterDropdown;
    [SerializeField]
    private TMP_InputField costInput;
    [SerializeField]
    private TMP_Dropdown typeDropdown;

    [Header("Unit Fields")]
    [SerializeField]
    private GameObject unitFieldArea;
    [SerializeField]
    private TMP_Dropdown attackFilterDropdown;
    [SerializeField]
    private TMP_InputField attackInput;
    [SerializeField]
    private TMP_Dropdown healthFilterDropdown;
    [SerializeField]
    private TMP_InputField healthInput;
    [SerializeField]
    private TMP_Dropdown rangeFilterDropdown;
    [SerializeField]
    private TMP_InputField rangeInput;
    [SerializeField]
    private TMP_Dropdown speedFilterDropdown;
    [SerializeField]
    private TMP_InputField speedInput;

    [Header("Spell Fields")]
    [SerializeField]
    private GameObject spellFieldArea;
    [SerializeField]
    private TMP_Dropdown spellRangeFilterDropdown;
    [SerializeField]
    private TMP_InputField spellRangeInput;

    [Header("Item Fields")]
    [SerializeField]
    private GameObject itemFieldArea;
    [SerializeField]
    private TMP_Dropdown durabilityFilterDropdown;
    [SerializeField]
    private TMP_InputField durabilityInput;

    private const string DEFAULT_DROPDOWN_STRING = "Any";

    private CardFunctionUI CardFunctionUI { get; set; }
    private CardListFilter TutorDrawFilter { get; set; }

    private List<TMP_Dropdown> dropdownFields;
    private List<TMP_InputField> inputFields;

    private bool isCreatedOn = false;

    /// <summary>
    /// 
    /// Initialises the tutor draw UI
    /// 
    /// </summary>
    public void InitTutorDraw(CardFunctionUI _cardFunctionUI)
    {
        CardFunctionUI = _cardFunctionUI;

        //Sets the list of dropdown fields and input fields
        dropdownFields = new List<TMP_Dropdown>
        {
            rarityDropdown,
            classDropdown,
            tagDropdown,
            resourceDropdown,
            typeDropdown,
            costFilterDropdown,
            attackFilterDropdown,
            healthFilterDropdown,
            rangeFilterDropdown,
            speedFilterDropdown,
            spellRangeFilterDropdown,
            durabilityFilterDropdown
        };
        inputFields = new List<TMP_InputField>
        {
            nameInput,
            costInput,
            attackInput,
            healthInput,
            rangeInput,
            speedInput,
            spellRangeInput,
            durabilityInput,
        };

        //Initialises the dropdowns on the UI
        GeneralUIExtensions.InitDropdownOfType(rarityDropdown, new List<Rarity> { Rarity.Default, Rarity.Deleted, Rarity.Hero, Rarity.NPCHero }, DEFAULT_DROPDOWN_STRING);
        GeneralUIExtensions.InitDropdownOfType(classDropdown, new List<Classes.ClassList> { Classes.ClassList.Default }, DEFAULT_DROPDOWN_STRING);
        GeneralUIExtensions.InitDropdownOfType(tagDropdown, new List<Tags> { Tags.Default }, DEFAULT_DROPDOWN_STRING, true);
        GeneralUIExtensions.InitDropdownOfType(resourceDropdown, new List<CardResources> { }, DEFAULT_DROPDOWN_STRING);
        GeneralUIExtensions.InitDropdownOfType(typeDropdown, new List<CardTypes> { CardTypes.Default }, DEFAULT_DROPDOWN_STRING);

        var removedIntValueFilter = new List<IntValueFilter> { IntValueFilter.None };
        GeneralUIExtensions.InitDropdownOfType(costFilterDropdown, removedIntValueFilter, DEFAULT_DROPDOWN_STRING);
        GeneralUIExtensions.InitDropdownOfType(attackFilterDropdown, removedIntValueFilter, DEFAULT_DROPDOWN_STRING);
        GeneralUIExtensions.InitDropdownOfType(healthFilterDropdown, removedIntValueFilter, DEFAULT_DROPDOWN_STRING);
        GeneralUIExtensions.InitDropdownOfType(rangeFilterDropdown, removedIntValueFilter, DEFAULT_DROPDOWN_STRING);
        GeneralUIExtensions.InitDropdownOfType(speedFilterDropdown, removedIntValueFilter, DEFAULT_DROPDOWN_STRING);
        GeneralUIExtensions.InitDropdownOfType(spellRangeFilterDropdown, removedIntValueFilter, DEFAULT_DROPDOWN_STRING);
        GeneralUIExtensions.InitDropdownOfType(durabilityFilterDropdown, removedIntValueFilter, DEFAULT_DROPDOWN_STRING);
    }

    /// <summary>
    /// 
    /// Initialises the tutor draw area when it is opened
    /// 
    /// </summary>
    public void OpenTutorDrawArea()
    {
        TutorDrawFilter = new CardListFilter();

        titleText.text = "Tutor Draw";

        //Sets area to default values
        dropdownFields.ForEach(x => x.value = 0);
        inputFields.ForEach(x => x.text = "");
        isCreatedToggle.isOn = false;
        isCreatedToggle.interactable = false;
        isChoiceToggle.isOn = false;
        IsChoiceToggleChange();

        OnCardTypeChange();
    }

    /// <summary>
    /// 
    /// Detect if the card type has changed. Called when area is opened and on value changed for the type dropdown
    /// 
    /// </summary>
    public void OnCardTypeChange()
    {
        unitFieldArea.SetActive(false);
        spellFieldArea.SetActive(false);
        itemFieldArea.SetActive(false);

        //If not the default value, then activates the valid type field area
        if (typeDropdown.captionText.text != DEFAULT_DROPDOWN_STRING)
        {
            var selectedType = (CardTypes)Enum.Parse(typeof(CardTypes), typeDropdown.captionText.text);

            switch (selectedType)
            {
                case CardTypes.Unit:
                    unitFieldArea.SetActive(true);
                    break;
                case CardTypes.Spell:
                    spellFieldArea.SetActive(true);
                    break;
                case CardTypes.Item:
                    itemFieldArea.SetActive(true);
                    break;
            }
        }
    }

    /// <summary>
    /// 
    /// Button click event for confirming the given filter and attempting to draw a card
    /// 
    /// </summary>
    public void ConfirmDraw()
    {
        //Sets the name filter to the name input
        TutorDrawFilter.Name = nameInput.text;

        //Determines if the is created filter is turned on. If not sets the value to null
        if (isCreatedOn)
            TutorDrawFilter.ScenarioCreated = isCreatedToggle.isOn;
        else
            TutorDrawFilter.ScenarioCreated = null;

        //Applies the dropdown filter to each of the relevant dropdowns
        ApplyDropdownFilter<Rarity>(rarityDropdown, TutorDrawFilter);
        ApplyDropdownFilter<Classes.ClassList>(classDropdown, TutorDrawFilter);
        ApplyDropdownFilter<Tags>(tagDropdown, TutorDrawFilter);
        ApplyDropdownFilter<CardResources>(resourceDropdown, TutorDrawFilter);
        ApplyDropdownFilter<CardTypes>(typeDropdown, TutorDrawFilter);

        ApplyDropdownFilter<IntValueFilter>(costFilterDropdown, TutorDrawFilter, CardListFilter.IntFilterTypes.Cost);
        ApplyDropdownFilter<IntValueFilter>(attackFilterDropdown, TutorDrawFilter, CardListFilter.IntFilterTypes.Attack);
        ApplyDropdownFilter<IntValueFilter>(healthFilterDropdown, TutorDrawFilter, CardListFilter.IntFilterTypes.Health);
        ApplyDropdownFilter<IntValueFilter>(rangeFilterDropdown, TutorDrawFilter, CardListFilter.IntFilterTypes.Range);
        ApplyDropdownFilter<IntValueFilter>(speedFilterDropdown, TutorDrawFilter, CardListFilter.IntFilterTypes.Speed);
        ApplyDropdownFilter<IntValueFilter>(spellRangeFilterDropdown, TutorDrawFilter, CardListFilter.IntFilterTypes.SpellRange);
        ApplyDropdownFilter<IntValueFilter>(durabilityFilterDropdown, TutorDrawFilter, CardListFilter.IntFilterTypes.Durability);

        int? choiceValue = 1;
        if (int.TryParse(isChoiceNumberInput.text, out int result) && isChoiceNumberInput.text != "0")
            choiceValue = Mathf.Max(1, result);
        choiceValue = isChoiceToggle.isOn ? choiceValue : null;
        //Attempt the draw using the constructed filter. If failed to draw with the given filter adds the clarifier to the title
        if (!CardFunctionUI.TutorDraw(TutorDrawFilter, choiceValue))
            titleText.text = $"{titleText.text} (Failed)";
    }

    /// <summary>
    /// 
    /// Apply the filter for a dropdown of a particular type
    /// 
    /// </summary>
    private CardListFilter ApplyDropdownFilter<T>(TMP_Dropdown dropdown, CardListFilter activeFilter, CardListFilter.IntFilterTypes intFilterType = CardListFilter.IntFilterTypes.None)
    {
        //If the text is All, do not need to apply the filter
        if (dropdown.captionText.text != DEFAULT_DROPDOWN_STRING)
        {
            //Parses the selected value into the enum
            var selectedField = (T)Enum.Parse(typeof(T), dropdown.captionText.text.Replace(" ", ""));
            var type = typeof(T);

            //Sets the filter to include the selected option based on the type of dropdown
            switch (type)
            {
                case Type _ when type == typeof(Rarity):
                    activeFilter.Rarity = (Rarity)(object)selectedField;
                    break;
                case Type _ when type == typeof(Classes.ClassList):
                    activeFilter.Class = (Classes.ClassList)(object)selectedField;
                    break;
                case Type _ when type == typeof(Tags):
                    activeFilter.Tag = (Tags)(object)selectedField;
                    break;
                case Type _ when type == typeof(CardResources):
                    activeFilter.Resource = (CardResources)(object)selectedField;
                    break;
                case Type _ when type == typeof(CardTypes):
                    activeFilter.CardType = (CardTypes)(object)selectedField;
                    break;
                case Type _ when type == typeof(IntValueFilter):
                    var intValueFilter = (IntValueFilter)(object)selectedField;

                    string inputText;

                    //Determines which type of filter type is required to check and stores the text
                    switch (intFilterType)
                    {
                        case CardListFilter.IntFilterTypes.Cost:
                            inputText = costInput.text;
                            break;
                        case CardListFilter.IntFilterTypes.Attack:
                            inputText = attackInput.text;
                            break;
                        case CardListFilter.IntFilterTypes.Health:
                            inputText = healthInput.text;
                            break;
                        case CardListFilter.IntFilterTypes.Range:
                            inputText = rangeInput.text;
                            break;
                        case CardListFilter.IntFilterTypes.Speed:
                            inputText = speedInput.text;
                            break;
                        case CardListFilter.IntFilterTypes.SpellRange:
                            inputText = spellRangeInput.text;
                            break;
                        case CardListFilter.IntFilterTypes.Durability:
                            inputText = durabilityInput.text;
                            break;
                        default:
                            throw new Exception("Not a valid int filter type");
                    }

                    int? result;

                    //Tries to parse the text result to an int 
                    if (int.TryParse(inputText, out int parseResult))
                        //Clamps the result to keep it positive
                        result = Mathf.Max(0, parseResult);
                    else
                        //If not a valid input, converts it to 0
                        result = 0;

                    //Adds the int filter to the filter
                    activeFilter.AddIntFilter(intFilterType, intValueFilter, result);

                    break;
            }
        }

        return activeFilter;
    }

    /// <summary>
    /// 
    /// Button click event for the is created button, turning on or off the toggle
    /// 
    /// </summary>
    public void IsCreatedButton()
    {
        isCreatedOn = !isCreatedOn;
        isCreatedToggle.interactable = isCreatedOn;
        isCreatedToggle.isOn = false;
    }

    public void IsChoiceToggleChange()
    {
        if (isChoiceToggle.isOn)
        {
            isChoiceNumberInput.interactable = true;
            isChoiceNumberInput.text = "3";
        }
        else
        {
            isChoiceNumberInput.interactable = false;
            isChoiceNumberInput.text = "";
        }
    }
}
