using CategoryEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class DeckData
{
    public string DeckName { get; set; }
    public List<CardData> CardList { get; set; }
    public int DeckCount { get; set; }
    public List<CardResources> DeckResources { get { return Classes.GetClassResource(DeckClass); } }
    public Classes.ClassList DeckClass { get; set; }
    public bool IsNPCDeck { get; set; }
}
