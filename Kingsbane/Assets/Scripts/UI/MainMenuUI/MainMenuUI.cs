using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private GameObject campaignUI;
    [SerializeField]
    private GameObject lobbyUI;
    [SerializeField]
    private GameObject libraryUI;

    /// <summary>
    /// 
    /// Button click event for opening the gampaign area
    /// 
    /// </summary>
    public void OpenCampaign()
    {
        campaignUI.SetActive(true);
        campaignUI.GetComponent<CampaignUI>().LoadCampaignUI();
    }

    /// <summary>
    /// 
    /// Button click event for opening the game lobby
    /// 
    /// </summary>
    public void OpenLobby()
    {
        lobbyUI.SetActive(true);
        lobbyUI.GetComponent<LobbyUI>().LoadLobbyUI();
    }

    /// <summary>
    /// 
    /// Button click event for opening the card library
    /// 
    /// </summary>
    public void OpenCardLibrary()
    {
        libraryUI.SetActive(true);
        libraryUI.GetComponent<CardLibraryParent>().RefreshCardLibrary();
    }

    /// <summary>
    /// 
    /// Button click event for exiting the game
    /// 
    /// </summary>
    public void ExitGame()
    {
        GameManager.instance.ExitGame();
    }
}
