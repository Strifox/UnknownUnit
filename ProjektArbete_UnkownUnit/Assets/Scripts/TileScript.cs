﻿using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
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

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

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
        ColorTile(occupiedTileColor);

        //Only tries to place a tower on the ground if the mouse is not over a button
        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.SelectedTower != null)
        {
            if(IsEmpty)
            {
                ColorTile(emptyTileColor);
            }
            if (!IsEmpty)
            {
                ColorTile(occupiedTileColor);
            }
            else if (Input.GetMouseButtonDown(0))
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
        GameObject tower = Instantiate(GameManager.Instance.SelectedTower.TowerPrefab, transform.position, Quaternion.identity);
        tower.transform.SetParent(transform);

        IsEmpty = false;
        GameManager.Instance.BuyTower();
        ColorTile(Color.white);
    }

    private void ColorTile(Color32 newColor)
    {
        spriteRenderer.color = newColor;
    }
}