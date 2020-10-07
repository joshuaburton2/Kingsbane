using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CategoryEnums;
using UnityEngine.EventSystems;

/// <summary>
/// 
/// Script for handling a class list object
/// 
/// </summary>
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

    /// <summary>
    /// 
    /// Initialise the class list object
    /// 
    /// </summary>
    public void InitClassListObject(Classes.ClassList _thisClass, NewDeckUI _newDeckUI)
    {
        //Requires new deck UI in order to reference back for the click event
        newDeckUI = _newDeckUI;
        thisClass = _thisClass;

        //If the class is not playable adds a clarifier to the text
        var isPlayableText = Classes.GetClassData(_thisClass).IsPlayable ? "" : @" <color=""white"">(!)</color=""white"">";
        nameText.text = thisClass.ToString().ToUpper() + isPlayableText;
        objectBackground.color = GameManager.instance.colourManager.GetClassColour(_thisClass);
        classIcon.sprite = GameManager.instance.iconManager.GetIcon(_thisClass);
    }

    /// <summary>
    /// 
    /// Click handler for clicking on class list object
    /// 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            newDeckUI.RefreshClassData(thisClass);
        }
    }
}
