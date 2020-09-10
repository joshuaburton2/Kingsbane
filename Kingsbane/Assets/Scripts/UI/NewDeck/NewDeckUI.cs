using CategoryEnums;
using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class NewDeckUI : MonoBehaviour
{
    public ClassData selectedClassData;
    private UnitData heroCard;

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

        if (selectedClassData.ThisClass == Classes.ClassList.Default)
        {
            classNameText.text = "-";
            dominantResourceText.text = "-";
            secondaryResourceText.text = "-";

            heroTierDropdown.interactable = false;
            abilityTierDropdown.interactable = false;
        }
        else
        {
            classNameText.text = selectedClassData.ClassName;
            dominantResourceText.text = selectedClassData.GetResourceOfType(ClassResourceType.ResourceTypes.Dominant).ToString();
            secondaryResourceText.text = selectedClassData.GetResourceOfType(ClassResourceType.ResourceTypes.Secondary).ToString();

            heroTierDropdown.interactable = true;
            abilityTierDropdown.interactable = true;
        }
        playstyleText.text = selectedClassData.GetStringData(ClassData.ClassDataFields.Playstyle);
        strengthText.text = selectedClassData.GetStringData(ClassData.ClassDataFields.Strengths);
        weaknessText.text = selectedClassData.GetStringData(ClassData.ClassDataFields.Weaknesses);
        descriptionText.text = selectedClassData.GetStringData(ClassData.ClassDataFields.Description);

        ResetHeroCard();
    }

    public void ResetHeroCard()
    {
        if (selectedClassData.ThisClass != Classes.ClassList.Default)
        {
            foreach (Transform child in heroCardArea.transform)
            {
                Destroy(child.gameObject);
            }

            var heroTier = (TierLevel)heroTierDropdown.value;
            var abilityTier = (TierLevel)abilityTierDropdown.value;

            heroCard = GameManager.instance.libraryManager.GetHero(selectedClassData.ThisClass, heroTier, abilityTier);
            var heroCardObject = GameManager.instance.libraryManager.CreateCard(heroCard, heroCardArea.transform);

            heroCardObject.name = $"Hero Card: {heroCard.Name}";
        }
    }
}
