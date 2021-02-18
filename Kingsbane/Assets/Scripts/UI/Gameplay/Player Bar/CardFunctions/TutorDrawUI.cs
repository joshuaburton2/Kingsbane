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
    public TMP_InputField nameInput;
    [SerializeField]
    public TMP_Dropdown rarityDropdown;
    [SerializeField]
    public TMP_Dropdown classDropdown;
    [SerializeField]
    public TMP_Dropdown tagDropdown;
    [SerializeField]
    public TMP_Dropdown resourceDropdown;
    [SerializeField]
    public Toggle isCreatedToggle;
    [SerializeField]
    public TMP_Dropdown costFilterDropdown;
    [SerializeField]
    public TMP_InputField costInput;
    [SerializeField]
    public TMP_Dropdown typeDropdown;

    [Header("Unit Fields")]
    [SerializeField]
    public GameObject unitFieldArea;
    [SerializeField]
    public TMP_Dropdown attackFilterDropdown;
    [SerializeField]
    public TMP_InputField attackInput;
    [SerializeField]
    public TMP_Dropdown healthFilterDropdown;
    [SerializeField]
    public TMP_InputField healthInput;
    [SerializeField]
    public TMP_Dropdown rangeFilterDropdown;
    [SerializeField]
    public TMP_InputField rangeInput;
    [SerializeField]
    public TMP_Dropdown speedFilterDropdown;
    [SerializeField]
    public TMP_InputField speedInput;

    [Header("Spell Fields")]
    [SerializeField]
    public GameObject spellFieldArea;
    [SerializeField]
    public TMP_Dropdown spellRangeFilterDropdown;
    [SerializeField]
    public TMP_InputField spellRangeInput;

    [Header("Item Fields")]
    [SerializeField]
    public GameObject itemFieldArea;
    [SerializeField]
    public TMP_Dropdown durabilityFilterDropdown;
    [SerializeField]
    public TMP_InputField durabilityInput;

    private const string DEFAULT_DROPDOWN_STRING = "Any";

    private CardFunctionUI cardFunctionUI;

    private CardListFilter tutorDrawFilter;

    private List<TMP_Dropdown> dropdownFields;
    private List<TMP_InputField> inputFields;

    public void InitTutorDraw(CardFunctionUI _cardFunctionUI)
    {
        cardFunctionUI = _cardFunctionUI;

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

        GeneralUIExtensions.InitDropdownOfType(rarityDropdown, new List<Rarity> { Rarity.Default, Rarity.Deleted, Rarity.Hero, Rarity.NPCHero }, DEFAULT_DROPDOWN_STRING);
        GeneralUIExtensions.InitDropdownOfType(classDropdown, new List<Classes.ClassList> { Classes.ClassList.Default }, DEFAULT_DROPDOWN_STRING);
        GeneralUIExtensions.InitDropdownOfType(tagDropdown, new List<Tags> { Tags.Default }, DEFAULT_DROPDOWN_STRING);
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

    public void OpenTutorDrawArea()
    {
        tutorDrawFilter = new CardListFilter();

        unitFieldArea.SetActive(true);
        spellFieldArea.SetActive(true);
        itemFieldArea.SetActive(true);

        dropdownFields.ForEach(x => x.value = 0);
        inputFields.ForEach(x => x.text = "");
        isCreatedToggle.isOn = false;

        OnCardTypeChange();
    }

    public void OnCardTypeChange()
    {
        unitFieldArea.SetActive(false);
        spellFieldArea.SetActive(false);
        itemFieldArea.SetActive(false);

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

    public void ConfirmDraw()
    {
        tutorDrawFilter.Name = nameInput.text;
        tutorDrawFilter.ScenarioCreated = isCreatedToggle.isOn;

        ApplyDropdownFilter<Rarity>(rarityDropdown, tutorDrawFilter);
        ApplyDropdownFilter<Classes.ClassList>(classDropdown, tutorDrawFilter);
        ApplyDropdownFilter<Tags>(tagDropdown, tutorDrawFilter);
        ApplyDropdownFilter<CardResources>(resourceDropdown, tutorDrawFilter);
        ApplyDropdownFilter<CardTypes>(typeDropdown, tutorDrawFilter);

        ApplyDropdownFilter<IntValueFilter>(costFilterDropdown, tutorDrawFilter, CardListFilter.IntFilterTypes.Cost);
        ApplyDropdownFilter<IntValueFilter>(attackFilterDropdown, tutorDrawFilter, CardListFilter.IntFilterTypes.Attack);
        ApplyDropdownFilter<IntValueFilter>(healthFilterDropdown, tutorDrawFilter, CardListFilter.IntFilterTypes.Health);
        ApplyDropdownFilter<IntValueFilter>(rangeFilterDropdown, tutorDrawFilter, CardListFilter.IntFilterTypes.Range);
        ApplyDropdownFilter<IntValueFilter>(speedFilterDropdown, tutorDrawFilter, CardListFilter.IntFilterTypes.Speed);
        ApplyDropdownFilter<IntValueFilter>(spellRangeFilterDropdown, tutorDrawFilter, CardListFilter.IntFilterTypes.SpellRange);
        ApplyDropdownFilter<IntValueFilter>(durabilityFilterDropdown, tutorDrawFilter, CardListFilter.IntFilterTypes.Durability);

        cardFunctionUI.TutorDraw(tutorDrawFilter);
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
            var selectedField = (T)Enum.Parse(typeof(T), dropdown.captionText.text);
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
                case Type _ when type == typeof(CardListFilter.IntFilterTypes):
                    var intValueFilter = (IntValueFilter)(object)selectedField;

                    switch (intFilterType)
                    {
                        case CardListFilter.IntFilterTypes.Cost:
                            activeFilter.AddIntFilter(intFilterType, intValueFilter, int.Parse(costInput.text));
                            break;
                        case CardListFilter.IntFilterTypes.Attack:
                            activeFilter.AddIntFilter(intFilterType, intValueFilter, int.Parse(attackInput.text));
                            break;
                        case CardListFilter.IntFilterTypes.Health:
                            activeFilter.AddIntFilter(intFilterType, intValueFilter, int.Parse(healthInput.text));
                            break;
                        case CardListFilter.IntFilterTypes.Range:
                            activeFilter.AddIntFilter(intFilterType, intValueFilter, int.Parse(rangeInput.text));
                            break;
                        case CardListFilter.IntFilterTypes.Speed:
                            activeFilter.AddIntFilter(intFilterType, intValueFilter, int.Parse(speedInput.text));
                            break;
                        case CardListFilter.IntFilterTypes.SpellRange:
                            activeFilter.AddIntFilter(intFilterType, intValueFilter, int.Parse(spellRangeInput.text));
                            break;
                        case CardListFilter.IntFilterTypes.Durability:
                            activeFilter.AddIntFilter(intFilterType, intValueFilter, int.Parse(durabilityInput.text));
                            break;
                        default:
                            throw new Exception("Not a valid int filter type");
                    }
                    break;
            }
        }

        return activeFilter;
    }
}
