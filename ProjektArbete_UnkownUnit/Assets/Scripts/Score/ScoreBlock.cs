using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBlock : MonoBehaviour
{
    public Text Name, Score;

    public void Display(ItemEntry item)
    {
        Name.text = item.PlayerName;
        Score.text = item.PlayerScore.ToString();
    }
}
