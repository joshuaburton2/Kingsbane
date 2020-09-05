using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CategoryEnums;

public class ClassListObject : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    Image objectBackground;
    [SerializeField]
    Image classIcon;

    public void InitClassListObject(Classes.ClassList thisClass)
    {
        nameText.text = thisClass.ToString().ToUpper();
        objectBackground.color =  GameManager.instance.colourManager.GetClassColour(thisClass);      
        classIcon.sprite = GameManager.instance.iconManager.getIcon(thisClass);
    }
}
