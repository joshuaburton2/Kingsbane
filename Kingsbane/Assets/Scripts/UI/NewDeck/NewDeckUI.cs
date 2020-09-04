using CategoryEnums;
using System;
using System.Linq;
using UnityEngine;

public class NewDeckUI : MonoBehaviour
{
    [SerializeField]
    GameObject classListParent;
    [SerializeField]
    GameObject classListPrefab;

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
