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
    private const int NUM_PLAYERS = 2;

    public GameModes gameMode;
    private GameModes SelectedGameMode { get { return (GameModes)Enum.Parse(typeof(GameModes), gameModeDropdown.captionText.text); } }
    private bool IsPVE { get { return gameMode == GameModes.PVE; } }

    [SerializeField]
    private TMP_Dropdown gameModeDropdown;

    [SerializeField]
    List<LobbyDeckListUI> playerDeckList;

    private DeckData[] playerDecks;

    public void LoadLobbyUI()
    {
        gameMode = SelectedGameMode;

        playerDecks = new DeckData[NUM_PLAYERS];       

        playerDeckList[0].RefreshDeckList(false, "Player 1 Deck List");
        playerDeckList[1].RefreshDeckList(IsPVE, IsPVE ? "NPC Deck List" : "Player 2 Deck List");
    }

    public void SwitchGameMode()
    {
        gameMode = SelectedGameMode;
        playerDeckList[1].RefreshDeckList(IsPVE, IsPVE ? "NPC Deck List" : "Player 2 Deck List");
    }

    public void SelectDeck(int playerId, DeckData deck)
    {
        playerDecks[playerId] = deck;
    }
}
