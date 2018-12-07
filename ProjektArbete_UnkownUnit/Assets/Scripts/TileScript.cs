using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

    public Point GridPosition { get; private set; }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Setup(Point gridPosition, Vector3 position, Transform parent)
    {
        GridPosition = gridPosition;
        transform.position = position;
        //Sets parent of the tiles to collapse it under one parent
        transform.SetParent(parent);
        //Add tiles to dictionary to be able to get the specific tile using Singleton
        MapManager.Instance.Tiles.Add(gridPosition, this);
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButton(0))
        { 
            PlaceTower();
        }
    }

    private void PlaceTower()
    {
        Instantiate(GameManager.Instance.TowerPrefab, transform.position, Quaternion.identity);
    }
}
