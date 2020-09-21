using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using CategoryEnums;
using System.Linq;

public class DeckManager : MonoBehaviour
{
    public List<DeckData> PlayerDeckList { get; private set; }
    public Dictionary<Classes.ClassList, List<DeckData>> DeckTemplates;
    private const string deckFileName = "/DeckData.dat";

    private void Awake()
    {
        LoadDecks();
    }

    public List<DeckData> GetPlayerDeckTemplates(Classes.ClassList neededClass)
    {
        var deckTemplates = DeckTemplates[neededClass].Where(x => x.IsNPCDeck == false).OrderBy(x => x.Name).ToList();
        return deckTemplates;
    }

    private void LoadDecks()
    {
        if(File.Exists(Application.persistentDataPath + deckFileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + deckFileName, FileMode.Open);
            PlayerDeckList = (List<DeckData>)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            PlayerDeckList = new List<DeckData>();
        }
    }

    private void SaveDecks()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + deckFileName);
        bf.Serialize(file, PlayerDeckList);
        file.Close();
    }

    public void ResetDecks()
    {
        if (File.Exists(Application.persistentDataPath + deckFileName))
        {
            File.Delete(Application.persistentDataPath + deckFileName);
        }

        PlayerDeckList = new List<DeckData>();
    }

    public void CreatePlayerDeck(DeckData deck, string deckName)
    {
        var newId = 0;
        if (PlayerDeckList.Count > 0)
        {
            newId = PlayerDeckList.LastOrDefault().Id + 1;
        }

        PlayerDeckList.Add(
            new DeckData(deck)
            {
                Id = newId,
                Name = deckName,
            });

        SaveDecks();
    }

    public void DeletePlayerDeck(DeckData deck)
    {
        PlayerDeckList.Remove(deck);
        SaveDecks();
    }

    public DeckData GetPlayerDeck(int id)
    {
        return PlayerDeckList.FirstOrDefault(x => x.Id == id);
    }

    public DeckData AddToPlayerDeck(int id, CardData cardData)
    {
        if (!cardData.IsHero && cardData.Rarity != Rarity.Uncollectable)
        {
            PlayerDeckList[id].AddCard(cardData);
            SaveDecks();
        }
        return PlayerDeckList[id];
    }

    public DeckData RemoveFromPlayerDeck(int id, CardData cardData)
    {
        if (!cardData.IsHero)
        {
            PlayerDeckList[id].RemoveCard(cardData);
            SaveDecks();
        }
        return PlayerDeckList[id];
    }
}
