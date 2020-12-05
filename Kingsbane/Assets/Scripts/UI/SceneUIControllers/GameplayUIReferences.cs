using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUIReferences : MonoBehaviour
{
    public GameObject cardDetailDisplay;
    public GameObject upgradeDetailDisplay;
    public GameObject gameplayUI;

    /// <summary>
    /// 
    /// Button click function for closing the given panel
    /// 
    /// </summary>
    public void ClosePanel(GameObject panel)
    {
        GameManager.instance.uiManager.ClosePanel(panel);
    }
}
