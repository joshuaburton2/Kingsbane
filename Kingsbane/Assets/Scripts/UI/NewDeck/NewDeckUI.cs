using CategoryEnums;
using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class NewDeckUI : MonoBehaviour
{
    [SerializeField]
    GameObject classListParent;
    [SerializeField]
    GameObject classListPrefab;

    [Header("Class Details Fields")]
    [SerializeField]
    TextMeshProUGUI classNameText;
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

    private void Start()
    {
        foreach (var newClass in Enum.GetValues(typeof(Classes.ClassList)).Cast<Classes.ClassList>())
        {
            if (newClass != Classes.ClassList.Default)
            {
                var classListObject = Instantiate(classListPrefab, classListParent.transform);
                classListObject.GetComponent<ClassListObject>().InitClassListObject(newClass);
            }
        }
    }

    public void InitNewDeckPage()
    {

    }
}
