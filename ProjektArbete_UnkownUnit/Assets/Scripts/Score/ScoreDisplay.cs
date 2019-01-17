using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public ScoreBlock blockPrefab;

    void Start()
    {
        foreach(ItemEntry item in XMLManager.ins.PlayerDb.list)
        {
            Display();
        }
    }

    public void Display()
    {
        foreach (ItemEntry item in XMLManager.ins.PlayerDb.list)
        {
            ScoreBlock newBlock = Instantiate(blockPrefab) as ScoreBlock;
            newBlock.transform.SetParent(transform, false);
            newBlock.Display(item);
        }
    }
}
