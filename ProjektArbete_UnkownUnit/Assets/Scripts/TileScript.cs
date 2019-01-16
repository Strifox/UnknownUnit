using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Assets.Entities;
using UnityEngine;
using UnityEngine.EventSystems;
using Pathfinding;
using UnityEditor.PackageManager.Requests;

public class TileScript : MonoBehaviour
{
    //TODO: Not Placing towers on correct tile

    public Point GridPosition { get; private set; }
    private Color32 occupiedTileColor = new Color32(255, 0, 0, 255);
    private SpriteRenderer spriteRenderer;
    private Color32 emptyTileColor = new Color32(0, 255, 250, 0);
    public bool IsEmpty { get; private set; }
    private GameObject tower;
    private Tower myTower;

    RaycastHit2D hit;


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

        PlaceTower();
    }

    private void OnMouseExit()
    {
        ColorTile(Color.white);
    }



    private void PlaceTower()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        //Only tries to place a tower on the ground if the mouse is not over a button
        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.TowerBtn != null && hit.collider.gameObject.tag != "Stone")
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    BuyTower();
                    Hover.Instance.Deactivate();
                    GameManager.Instance.TowerBtn = null;
                }
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetMouseButtonDown(0))
                    BuyTower();
            }
            if (IsEmpty)
            {
                ColorTile(emptyTileColor);
            }
            if (!IsEmpty)
            {
                ColorTile(occupiedTileColor);
            }
        }
        else if (GameManager.Instance.TowerBtn == null && Input.GetMouseButtonDown(0))
        {
            if (myTower != null)
            {
                GameManager.Instance.EnableRange(myTower);
            }
            else
            {
                GameManager.Instance.DisableRange();
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GraphNode node1 = AstarPath.active.GetNearest(new Vector3 { x = -14.5f, y = -2f, z = 0 }, NNConstraint.Default).node;
        GraphNode node2 = AstarPath.active.GetNearest(new Vector3 { x = 20f, y = -1.41f, z = 0 }, NNConstraint.Default).node;

        tower = GameObject.FindGameObjectWithTag("Tower");

        if (!PathUtilities.IsPathPossible(node1, node2) && tower.tag == "Tower")
        {
            Destroy(tower);
            Debug.Log("You are blocking path!");
        }

    }
    private void BuyTower()
    {
        if (GameManager.Instance.Gold >= GameManager.Instance.TowerBtn.Price)
        {
            tower = (GameObject)Instantiate(GameManager.Instance.TowerBtn.TowerPrefab, transform.position, Quaternion.identity);
            tower.transform.SetParent(transform);
            this.myTower = tower.transform.GetChild(0).GetComponent<Tower>();
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