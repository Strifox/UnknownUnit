using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Assets.Entities;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{
    //TODO: Not Placing towers on correct tile


    public Point GridPosition { get; private set; }
    private Color32 occupiedTileColor = new Color32(255, 0, 0, 255);
    private Color32 emptyTileColor = new Color32(0, 255, 250, 0);
    private SpriteRenderer spriteRenderer;
    public bool IsEmpty { get; private set; }
    bool isLeftShiftPressed = false;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Hover.Instance.Deactivate();
            GameManager.Instance.TowerBtn = null;
        }
    }

    public void Setup(Point gridPosition, Vector3 position, Transform parent)
    {
        IsEmpty = true;
        GridPosition = gridPosition;
        transform.position = position;
        //Sets parent of the tiles to collapse it under one parent
        transform.SetParent(parent);
        //Add tiles to dictionary to be able to get the specific tile using Singleton
        MapManager.Instance.Tiles.Add(gridPosition, this);
    }

    void OnMouseOver()
    {
        //ColorTile(occupiedTileColor);

        //Only tries to place a tower on the ground if the mouse is not over a button
        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.TowerBtn != null)
        {
            if(IsEmpty)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    PlaceTower();
                    Hover.Instance.Deactivate();
                    GameManager.Instance.TowerBtn = null;
                }
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetMouseButtonDown(0))
                    PlaceTower();
            }
            if (IsEmpty)
            {
                ColorTile(emptyTileColor);
            }
            if (!IsEmpty)
            {
                ColorTile(occupiedTileColor);
            }
            if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
            {
                PlaceTower();
                Hover.Instance.Deactivate();
                GameManager.Instance.TowerBtn = null;
            }
            if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftShift))
            {
                PlaceTower();
            }
        }
    }

    private void OnMouseExit()
    {
        ColorTile(Color.white);
    }

    private void PlaceTower()
    {
        if(GameManager.Instance.Gold >= GameManager.Instance.TowerBtn.Price)
        {
            GameObject tower = Instantiate(GameManager.Instance.TowerBtn.TowerPrefab, transform.position, Quaternion.identity);
            tower.transform.SetParent(transform);
            IsEmpty = false;
            GameManager.Instance.BuyTower();
            ColorTile(Color.white);
        }
    }

    private void ColorTile(Color32 newColor)
    {
        spriteRenderer.color = newColor;
    }
}

            if (!Input.GetKey(KeyCode.LeftShift))