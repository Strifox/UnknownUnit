using Assets.Entities;
using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBtn : MonoBehaviour
{

    public Tower SelectedTower;
    private Image image;
    private Button button;
    private Text price;

    void Start()
    {
        image = GetComponent<Image>();
        price = GetComponentInChildren<Text>();
        button = GetComponent<Button>();
    }

    void Update()
    {
        EnableLabels();

        SelectTower();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SelectedTower = null;
        }
    }

    private void SelectTower()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Tower"))
                    SelectedTower = hit.transform.gameObject.GetComponent<Tower>();
                else if(hit.collider.CompareTag("UI"))
                {

                }
                else
                {
                    SelectedTower = null;
                }
            }
            else
            {
                SelectedTower = null;
            }
        }
    }

    private void EnableLabels()
    {
        if (SelectedTower == null)
        {
            image.enabled = false;
            price.enabled = false;
        }
        else
        {
            image.enabled = true;
            price.enabled = true;
            if (SelectedTower.Level < 5)
                price.text = "Price " + SelectedTower.UpgradeCost;
            else
            {
                price.text = "MAX LEVEL";
                button.transition = Selectable.Transition.None;
            }
        }
    }

    public void UpgradeTower()
    {
        if (GameManager.Instance.Gold >= SelectedTower.UpgradeCost && SelectedTower.Level < 5)
        {
            SelectedTower.Damage += 20;
            SelectedTower.Level++;
            var preUpgradeCost = SelectedTower.UpgradeCost;
            SelectedTower.UpgradeCost += 20;
            SelectedTower.TotalCost += preUpgradeCost;
            GameManager.Instance.Gold -= preUpgradeCost;
        }
    }
}
