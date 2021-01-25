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
    [SerializeField]
    private MapCameraController mapCameraController;

    public void OnPointerEnter(PointerEventData eventData)
    {
        mapCameraController.isOverGameplayArea = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mapCameraController.isOverGameplayArea = false;
    }
}
