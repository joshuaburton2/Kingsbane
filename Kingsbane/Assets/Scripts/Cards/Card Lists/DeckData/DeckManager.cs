using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using CategoryEnums;
using System.Linq;

public class DeckManager : MonoBehaviour
{
    [SerializeField]
    private LibraryManager libraryManager;

    public List<DeckData> PlayerDeckList { get; private set; }
    public Dictionary<Classes.ClassList, List<DeckData>> DeckTemplates;
    private const string deckFileName = "/DeckData.dat";

    private List<DeckData> ConvertDeckSave(List<DeckSaveData> deckSaveDatas)
    {
        var deckDatas = new List<DeckData>();
        foreach (var saveDeck in deckSaveDatas)
        {
            deckDatas.Add(new DeckData(saveDeck, libraryManager));
        }

        return deckDatas;
    }

    public List<DeckData> GetPlayerDeckTemplates(Classes.ClassList neededClass)
    {
        var classData = Classes.ClassDataList.FirstOrDefault(x => x.ThisClass == neededClass);
        var deckSaveTemplates = classData.DeckTemplates.Where(x => x.IsNPCDeck == false).OrderBy(x => x.Name).ToList();

        return ConvertDeckSave(deckSaveTemplates);
    }

    public void LoadDecks()
    {
        if(File.Exists(Application.persistentDataPath + deckFileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + deckFileName, FileMode.Open);
            var saveDeckList = (List<DeckSaveData>)bf.Deserialize(file);

            PlayerDeckList = ConvertDeckSave(saveDeckList);

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

        var saveDeckList = new List<DeckSaveData>();
        foreach (var deck in PlayerDeckList)
        {
            saveDeckList.Add(new DeckSaveData(deck));
        }

        bf.Serialize(file, saveDeckList);
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
