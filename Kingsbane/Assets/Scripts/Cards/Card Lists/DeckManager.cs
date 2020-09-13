using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using CategoryEnums;
using System.Linq;

public class DeckManager : MonoBehaviour
{
    private List<DeckData> DeckList;
    public Dictionary<Classes.ClassList, List<DeckData>> DeckTemplates;
    private const string deckFileName = "/DeckData.dat";

    private void Awake()
    {
        LoadDecks();
    }

    public List<DeckData> GetDeckTemplates(Classes.ClassList neededClass, bool isNPCDeck)
    {
        var deckTemplates = DeckTemplates[neededClass].Where(x => x.IsNPCDeck == isNPCDeck).OrderBy(x => x.Name).ToList();
        return deckTemplates;
    }

    public void LoadDecks()
    {
        if(File.Exists(Application.persistentDataPath + deckFileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + deckFileName, FileMode.Open);
            DeckList = (List<DeckData>)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            DeckList = new List<DeckData>();
        }
    }

    public void SaveDecks()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + deckFileName);
        bf.Serialize(file, DeckList);
        file.Close();
    }

    public void ResetDecks()
    {
        if (File.Exists(Application.persistentDataPath + deckFileName))
        {
            File.Delete(Application.persistentDataPath + deckFileName);
        }
    }
}
