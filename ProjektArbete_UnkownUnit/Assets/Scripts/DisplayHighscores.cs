using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour
{
    public Text text;
    private PlayerDatabase playerDatabase;

    void Start()
    {
        XMLManager.ins.Load();
        playerDatabase = XMLManager.ins.PlayerDb;
        playerDatabase.list.Sort((p1, p2) => p2.PlayerScore.CompareTo(p1.PlayerScore));
        foreach(ItemEntry item in playerDatabase.list)
        {
            text.text += item.PlayerName + " " + item.PlayerScore.ToString() + "\n";
        }
        
    }
}
