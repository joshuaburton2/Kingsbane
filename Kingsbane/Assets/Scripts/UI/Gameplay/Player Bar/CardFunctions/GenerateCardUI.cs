using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GenerateCardUI : MonoBehaviour
{
    [Header("Generic Fields")]
    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private TMP_InputField nameInput;
    [SerializeField]
    private TMP_Dropdown classDropdown;
    [SerializeField]
    private TMP_Dropdown tagDropdown;
    [SerializeField]
    private TMP_Dropdown resourceDropdown;
    [SerializeField]
    private TMP_Dropdown typeDropdown;
    [SerializeField]
    private Toggle includeUncollectablesToggle;
    [SerializeField]
    private TMP_InputField numToGenerateInput;
    [SerializeField]
    private GameObject positionFieldArea;
    [SerializeField]
    private TMP_Dropdown positionDropdown;

    private const string DEFAULT_DROPDOWN_STRING = "Any";

    private CardFunctionUI CardFunctionUI { get; set; }
    private Classes.ClassList PlayerClass { get; set; }
    private GenerateCardFilter GenerationFilter { get; set; }
    public CardGenerationTypes CardGenerationType { get; set; }

    private List<TMP_Dropdown> dropdownFields;
    private List<TMP_InputField> inputFields;

    /// <summary>
    /// 
    /// Initialises the tutor draw UI
    /// 
    /// </summary>
    public void InitGenerateCard(CardFunctionUI _cardFunctionUI, Classes.ClassList playerClass)
    {
        CardFunctionUI = _cardFunctionUI;
        PlayerClass = playerClass;

        //Sets the list of dropdown fields and input fields
        dropdownFields = new List<TMP_Dropdown>
        {
            classDropdown,
            tagDropdown,
            resourceDropdown,
            typeDropdown,
            positionDropdown
        };
        inputFields = new List<TMP_InputField>
        {
            nameInput,
            numToGenerateInput,
        };

        //Initialises the dropdowns on the UI
        GeneralUIExtensions.InitDropdownOfType(classDropdown, new List<Classes.ClassList> { Classes.ClassList.Default }, DEFAULT_DROPDOWN_STRING);
        GeneralUIExtensions.InitDropdownOfType(tagDropdown, new List<Tags> { Tags.Default }, DEFAULT_DROPDOWN_STRING, true);
        GeneralUIExtensions.InitDropdownOfType(resourceDropdown, new List<CardResources> { }, DEFAULT_DROPDOWN_STRING);
        GeneralUIExtensions.InitDropdownOfType(typeDropdown, new List<CardTypes> { CardTypes.Default }, DEFAULT_DROPDOWN_STRING);
        GeneralUIExtensions.InitDropdownOfType(positionDropdown, new List<DeckPositions>());
    }

    /// <summary>
    /// 
    /// Initialises the tutor draw area when it is opened
    /// 
    /// </summary>
    public void OpenGenerateCardArea(CardGenerationTypes cardGenerationType)
    {
        CardGenerationType = cardGenerationType;

        GenerationFilter = new GenerateCardFilter(PlayerClass);

        titleText.text = $"Add to {CardGenerationType}";

        //Sets area to default values
        dropdownFields.ForEach(x => x.value = 0);
        inputFields.ForEach(x => x.text = "");
        includeUncollectablesToggle.isOn = false;

        //Hides the position field 
        positionFieldArea.SetActive(CardGenerationType == CardGenerationTypes.Deck);
    }

    /// <summary>
    /// 
    /// Button click event for confirming the given filter and attempting to draw a card
    /// 
    /// </summary>
    public void ConfirmGeneration()
    {
        //Sets the name filter to the name input
        GenerationFilter.Name = nameInput.text;
        GenerationFilter.IncludeUncollectables = includeUncollectablesToggle.isOn;

        //Applies the dropdown filter to each of the relevant dropdowns
        ApplyDropdownFilter<Classes.ClassList>(classDropdown, GenerationFilter);
        ApplyDropdownFilter<Tags>(tagDropdown, GenerationFilter);
        ApplyDropdownFilter<CardResources>(resourceDropdown, GenerationFilter);
        ApplyDropdownFilter<CardTypes>(typeDropdown, GenerationFilter);

        //Attempts the generation of cards. For deck generation, includes the position to place the generated card
        bool successfulGeneration;
        if (CardGenerationType == CardGenerationTypes.Deck)
        {
            var position = (DeckPositions)Enum.Parse(typeof(DeckPositions), positionDropdown.captionText.text);
            successfulGeneration = CardFunctionUI.ConfirmCardGeneration(GenerationFilter, position);
        }
        else
            successfulGeneration = CardFunctionUI.ConfirmCardGeneration(GenerationFilter);

        //If failed the generation, displays this in the title
        if (!successfulGeneration)
            titleText.text = $"{titleText.text} (Failed)";
    }

    /// <summary>
    /// 
    /// Apply the filter for a dropdown of a particular type
    /// 
    /// </summary>
    private GenerateCardFilter ApplyDropdownFilter<T>(TMP_Dropdown dropdown, GenerateCardFilter activeFilter)
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
            }
        }

        return activeFilter;
    }
}
