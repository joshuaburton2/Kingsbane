using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Script to assign to the parent of the card library.
/// 
/// </summary>
public class CardLibraryParent : MonoBehaviour
{
    [SerializeField]
    LibraryUI libraryUI;
    [SerializeField]
    DeckListUI deckListUI;

    /// <summary>
    /// 
    /// Initialises the card library when it is first opened
    /// 
    /// </summary>
    public void RefreshCardLibrary()
    {
        libraryUI.LibraryInitialisation();
        deckListUI.RefreshDeckList(false);
    }
}
