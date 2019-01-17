using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{

    [SerializeField]
    public GameObject[] tilePrefabs = new GameObject[] { };

    [SerializeField]
    private CameraMovement cameraMovement;

    //Sets reference to set map as a parent
    [SerializeField]
    private Transform map;

    public Dictionary<Point, TileScript> Tiles;

    //Sets the X tile width to the same as SpriteRenderer element 0 in MapManager
    public float TileSize { get { return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; } }

    // Use this for initialization
    void Start()
    {
        
    }

    private void Awake()
    {
        CreateMap();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void CreateMap()
    {
        Tiles = new Dictionary<Point, TileScript>();

        string[] mapData = ReadMapText();

        //Sets the size of the X position
        int mapX = mapData[0].ToCharArray().Length;
        //Sets the size of the Y position
        int mapY = mapData.Length;

        //Sets to zero so it doesn't complain as unassigned.
        Vector3 maxTile = Vector3.zero;

        //Sets the creating of the map start point to the top left corner.
        Vector3 mapStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height)); 

        for (int y = 0; y < mapY; y++)
        {
            char[] newTiles = mapData[y].ToCharArray();

            for (int x = 0; x < mapX; x++)
            {
                //Placing the tiles
                PlaceTile(newTiles[x].ToString(), x, y, mapStart);
            }
        }

        //Takes the position of the last tile and stores it in maxTile and passes its to cameraMovement
        //maxTile = Tiles[new Point(mapX - 1, mapY - 1)].transform.position;

        //cameraMovement.SetCameraLimits(new Vector3(maxTile.x + TileSize, maxTile.y -TileSize));
    }

    private void PlaceTile(string tileArray, int x, int y, Vector3 mapStart)
    {
        //Parsing tile so it can be used as an indexer when we create a new tile
        int tileIndex = int.Parse(tileArray);

        //Creates a new tile with a reference to the specific tile that is parsed
        TileScript newTile = Instantiate(tilePrefabs[tileIndex]).GetComponent<TileScript>();

        //Using the newTile to change the position of the tile
        newTile.Setup(new Point(x, y), new Vector3(mapStart.x + (TileSize * x), mapStart.y - (TileSize * y), 0), map);
     
    }

    //Reads from TextFile
    private string[] ReadMapText()
    {
        TextAsset data = Resources.Load("Map") as TextAsset;
        //Replaces newlines with empty string.
        string newData = data.text.Replace(Environment.NewLine, string.Empty);
        //Splits the line at all '-' characters
        return newData.Split('-');
    }
}
