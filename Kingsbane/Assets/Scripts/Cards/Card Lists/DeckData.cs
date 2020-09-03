using CategoryEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class DeckData
{
    public string deckName;
    public List<CardData> cardList;
    public int deckCount;
    public List<CardResources> DeckResources { get { return Classes.GetClassResource(deckClass); } }
    public Classes.ClassList deckClass;
}
