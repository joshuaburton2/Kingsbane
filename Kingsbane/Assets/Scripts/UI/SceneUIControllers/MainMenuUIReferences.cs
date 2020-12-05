using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIReferences : MonoBehaviour
{
    public GameObject cardDetailDisplay;
    public GameObject upgradeDetailDisplay;
    public GameObject lobbyUI;
    public GameObject libraryUI;

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
