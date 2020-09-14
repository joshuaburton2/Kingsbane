using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CategoryEnums;
using UnityEngine.EventSystems;

public class ClassListObject : MonoBehaviour, IPointerClickHandler
{
    NewDeckUI newDeckUI;
    Classes.ClassList thisClass;

    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    Image objectBackground;
    [SerializeField]
    Image classIcon;

    public void InitClassListObject(Classes.ClassList _thisClass, NewDeckUI _newDeckUI)
    {
        newDeckUI = _newDeckUI;
        thisClass = _thisClass;

        var isPlayableText = Classes.GetClassData(_thisClass).IsPlayable ? "" : @" <color=""white"">(!)</color=""white"">";
        nameText.text = thisClass.ToString().ToUpper() + isPlayableText;
        objectBackground.color = GameManager.instance.colourManager.GetClassColour(_thisClass);
        classIcon.sprite = GameManager.instance.iconManager.getIcon(_thisClass);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        newDeckUI.RefreshClassData(thisClass);
    }
}
