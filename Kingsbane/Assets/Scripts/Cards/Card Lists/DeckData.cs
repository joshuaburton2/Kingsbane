using CategoryEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class DeckData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<CardData> CardList { get; set; }
    public int DeckCount { get { return CardList.Count; } }
    public List<CardResources> DeckResources { get { return Classes.GetClassData(DeckClass).GetClassResources(); } }
    public Classes.ClassList DeckClass { get; set; }
    public bool IsNPCDeck { get; set; }

    public DeckData()
    {
        Id = -1;
    }

    public DeckData(DeckData deckData)
    {
        Id = deckData.Id;
        Name = deckData.Name;
        CardList = deckData.CardList.ToList();
        DeckClass = deckData.DeckClass;
        IsNPCDeck = deckData.IsNPCDeck;
    }

    public void AddCard(CardData cardData)
    {
        CardList.Add(cardData);
        CardList = LibraryManager.OrderCardList(CardList);
    }
}
