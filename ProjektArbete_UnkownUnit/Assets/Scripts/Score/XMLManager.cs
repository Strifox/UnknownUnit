using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using UnityEngine.UI;

public class XMLManager : MonoBehaviour
{
    public static XMLManager ins;
    public InputField NameTextBox;
    public GameObject GameOverManager;
    public PlayerDatabase PlayerDb;

    void Awake()
    {
        ins = this;
    }

    void Start()
    {
        Load();
    }

    public void Save()
    {
        PlayerDb.list.Add(new ItemEntry { PlayerName = NameTextBox.text, PlayerScore = GameOver.PlayerScore });
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/Resources/scores.xml", FileMode.Create, FileAccess.ReadWrite, FileShare.None);
        serializer.Serialize(stream, PlayerDb);
        stream.Close();
    }

    public void Load()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/Resources/scores.xml", FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        PlayerDb = serializer.Deserialize(stream) as PlayerDatabase;
        stream.Close();
    }
}

[System.Serializable]
public class ItemEntry
{
    public string PlayerName;
    public int PlayerScore;
}

[System.Serializable]
public class PlayerDatabase
{
    [XmlArray("Players")]
    public List<ItemEntry> list = new List<ItemEntry>();
}
