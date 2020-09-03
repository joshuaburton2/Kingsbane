using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<DeckData> DeckList { get; set; }
    private const string deckFileName = "/DeckData.dat";

    private void Awake()
    {
        LoadDecks();
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
