using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] tilePrefabs = new GameObject[] { };

    public float TileSize { get { return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; } }

    // Use this for initialization
    void Start()
    {
        CreateMap();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateMap()
    {
        string[] mapData = ReadMapText();

        int mapX = mapData[0].ToCharArray().Length;
        int mapY = mapData.Length;

        Vector3 mapStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

        for (int y = 0; y < mapY; y++)
        {
            char[] newTiles = mapData[y].ToCharArray();

            for (int x = 0; x < mapX; x++)
            {
                PlaceTile(newTiles[x].ToString(), x, y, mapStart);
            }
        }
    }

    private void PlaceTile(string tileArray, int x, int y, Vector3 mapStart)
    {
        int tileIndex = int.Parse(tileArray);

        GameObject newTile = Instantiate(tilePrefabs[tileIndex]);

        //Changes the position of newTile
        newTile.transform.position = new Vector3(mapStart.x + (TileSize * x), mapStart.y - (TileSize * y), 0);
    }

    //Reads from TextFile
    private string[] ReadMapText()
    {
        TextAsset data = Resources.Load("Map") as TextAsset;
        string newData = data.text.Replace(Environment.NewLine, string.Empty);

        return newData.Split('-');
    }
}
