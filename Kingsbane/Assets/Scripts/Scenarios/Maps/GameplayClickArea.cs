using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 
/// Script for detecting if the mouse is over the gameplay area. Needs to be assigned to a transparent image object which is over the gameplay area
/// 
/// </summary>
public class GameplayClickArea : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameManager.instance.uiManager.OverGameplayArea = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameManager.instance.uiManager.OverGameplayArea = false;
    }
}
