using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public enum GameModes
{
    PVP,
    PVE,
}

public class LobbyUI : MonoBehaviour
{
    public GameModes gameMode;
    private GameModes SelectedGameMode { get { return (GameModes)Enum.Parse(typeof(GameModes), gameModeDropdown.captionText.text); } }
    private bool IsPVE { get { return gameMode == GameModes.PVE; } }

    [SerializeField]
    private TMP_Dropdown gameModeDropdown;

    [SerializeField]
    LobbyDeckListUI PlayerOneDeckList;
    [SerializeField]
    LobbyDeckListUI PlayerTwoDeckList;

    public void LoadLobbyUI()
    {
        gameMode = SelectedGameMode;

        PlayerOneDeckList.RefreshDeckList(false, "Player 1 Deck List");
        PlayerTwoDeckList.RefreshDeckList(IsPVE, IsPVE ? "NPC Deck List" : "Player 2 Deck List");
    }

    public void SwitchGameMode()
    {
        gameMode = SelectedGameMode;
        PlayerTwoDeckList.RefreshDeckList(IsPVE, IsPVE ? "NPC Deck List" : "Player 2 Deck List");
    }
}
