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
    private Toggle isUnique;
    [SerializeField]
    private TMP_InputField numToGenerateInput;
    [SerializeField]
    private TMP_InputField createdByInput;
    [SerializeField]
    private GameObject positionFieldArea;
    [SerializeField]
    private TMP_Dropdown positionDropdown;

    [Header("Unit Enchantment Area")]
    [SerializeField]
    private GameObject unitEnchantmentArea;
    [SerializeField]
    private TMP_Dropdown attackModTypeDropdown;
    [SerializeField]
    private TMP_InputField attackValueInput;
    [SerializeField]
    private TMP_Dropdown healthModTypeDropdown;
    [SerializeField]
    private TMP_InputField healthValueInput;
    [SerializeField]
    private TMP_Dropdown rangeModTypeDropdown;
    [SerializeField]
    private TMP_InputField rangeValueInput;
    [SerializeField]
    private TMP_Dropdown speedModTypeDropdown;
    [SerializeField]
    private TMP_InputField speedValueInput;
    [SerializeField]
    private TMP_Dropdown empoweredModTypeDropdown;
    [SerializeField]
    private TMP_InputField empoweredValueInput;

    private const string DEFAULT_DROPDOWN_STRING = "Any";
    private string defaultTitleText;

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

        ClearEnchantmentFields();
        unitEnchantmentArea.SetActive(false);

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
            createdByInput,
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
        defaultTitleText = titleText.text;
        createdByInput.placeholder.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);

        //Sets area to default values
        dropdownFields.ForEach(x => x.value = 0);
        inputFields.ForEach(x => x.text = "");
        includeUncollectablesToggle.isOn = false;
        isUnique.isOn = false;

        //Hides the position field 
        positionFieldArea.SetActive(CardGenerationType == CardGenerationTypes.Deck);
    }

    /// <summary>
    /// 
    /// Button click event for confirming the given filter and attempting to generate a card
    /// 
    /// </summary>
    public void ConfirmGeneration()
    {
        //In order to submit, needs to have a created by string. Doesn't confirm if there is no text, and displays error to player
        if (!string.IsNullOrWhiteSpace(createdByInput.text))
        {
            //Sets the name filter to the name input
            GenerationFilter.Name = nameInput.text;
            GenerationFilter.IncludeUncollectables = includeUncollectablesToggle.isOn;
            GenerationFilter.IsUnique = isUnique.isOn;
            if (!string.IsNullOrWhiteSpace(numToGenerateInput.text))
                GenerationFilter.NumToGenerate = int.Parse(numToGenerateInput.text);

            //Applies the dropdown filter to each of the relevant dropdowns
            ApplyDropdownFilter<Classes.ClassList>(classDropdown, GenerationFilter);
            ApplyDropdownFilter<Tags>(tagDropdown, GenerationFilter);
            ApplyDropdownFilter<CardResources>(resourceDropdown, GenerationFilter);
            ApplyDropdownFilter<CardTypes>(typeDropdown, GenerationFilter);

            //If the card type is a unit, constructs the enchantment and adds it to the filter for generation
            if (GenerationFilter.CardType == CardTypes.Unit)
            {
                var enchantment = new UnitEnchantment() { Status = UnitEnchantment.EnchantmentStatus.Permanent, Source = createdByInput.text };
                GetStatModifier(enchantment, Unit.StatTypes.Attack, attackModTypeDropdown, attackValueInput);
                GetStatModifier(enchantment, Unit.StatTypes.MaxHealth, healthModTypeDropdown, healthValueInput);
                GetStatModifier(enchantment, Unit.StatTypes.Range, rangeModTypeDropdown, rangeValueInput);
                GetStatModifier(enchantment, Unit.StatTypes.Speed, speedModTypeDropdown, speedValueInput);
                GetStatModifier(enchantment, Unit.StatTypes.Empowered, empoweredModTypeDropdown, empoweredValueInput);

                if(enchantment.ValidEnchantment)
                    GenerationFilter.Enchantment = enchantment;
            }

            ClearEnchantmentFields();

            //Attempts the generation of cards. For deck generation, includes the position to place the generated card
            bool successfulGeneration;
            if (CardGenerationType == CardGenerationTypes.Deck)
            {
                var position = (DeckPositions)Enum.Parse(typeof(DeckPositions), positionDropdown.captionText.text);
                successfulGeneration = CardFunctionUI.ConfirmCardGeneration(GenerationFilter, createdByInput.text, position);
            }
            else
                successfulGeneration = CardFunctionUI.ConfirmCardGeneration(GenerationFilter, createdByInput.text);

            //If failed the generation, displays this in the title
            if (!successfulGeneration)
                titleText.text = $"{defaultTitleText} (Failed)";
        }
        else
        {
            createdByInput.placeholder.color = new Color(0.8f, 0.0f, 0.0f, 0.5f);
            titleText.text = $"{defaultTitleText} (Input Created By)";
        }
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

    /// <summary>
    /// 
    /// Opens the unit enchantment area if the card type is a unit. Closes otherwise
    /// 
    /// </summary>
    public void CardTypeChange()
    {
        switch ((CardTypes)Enum.Parse(typeof(CardTypes), typeDropdown.captionText.text.Replace(" ", "")))
        {
            case CardTypes.Unit:
                unitEnchantmentArea.SetActive(true);
                ClearEnchantmentFields();
                break;
            default:
                unitEnchantmentArea.SetActive(false);
                break;
        }
    }

    /// <summary>
    /// 
    /// Clears the enchantment fields back to their default state
    /// 
    /// </summary>
    private void ClearEnchantmentFields()
    {
        GeneralUIExtensions.InitDropdownOfType(attackModTypeDropdown, new List<StatModifierTypes>());
        GeneralUIExtensions.InitDropdownOfType(healthModTypeDropdown, new List<StatModifierTypes>());
        GeneralUIExtensions.InitDropdownOfType(rangeModTypeDropdown, new List<StatModifierTypes>());
        GeneralUIExtensions.InitDropdownOfType(speedModTypeDropdown, new List<StatModifierTypes>());
        GeneralUIExtensions.InitDropdownOfType(empoweredModTypeDropdown, new List<StatModifierTypes>());

        attackValueInput.text = "";
        healthValueInput.text = "";
        rangeValueInput.text = "";
        speedValueInput.text = "";
        empoweredValueInput.text = "";
    }

    /// <summary>
    /// 
    /// Adds the stat modifier to the enchantment for a particular stat type dropdown and an input
    /// 
    /// </summary>
    private void GetStatModifier(UnitEnchantment enchantment, Unit.StatTypes statType, TMP_Dropdown statModTypeDropdown, TMP_InputField statValueInput)
    {
        var statModType = (StatModifierTypes)Enum.Parse(typeof(StatModifierTypes), statModTypeDropdown.captionText.text);

        if (statModType != StatModifierTypes.None)
        {
            if (string.IsNullOrWhiteSpace(statValueInput.text))
                statValueInput.text = "0";
            var statValue = int.Parse(statValueInput.text);

            enchantment.AddStatModifier(statType, statModType, statValue);
        }
    }

    /// <summary>
    /// 
    /// Button click event for reseting the filter
    /// 
    /// </summary>
    public void ResetButton()
    {
        ClearEnchantmentFields();
    }
}
