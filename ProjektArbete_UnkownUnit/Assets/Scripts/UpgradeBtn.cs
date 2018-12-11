using Assets.Entities;
using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class UpgradeBtn : MonoBehaviour {

	public Tower SelectedTower;
	private UnityEngine.UI.Image image;
	private Text price;

	void Start () {
		image = GetComponent<UnityEngine.UI.Image>();
		price = GetComponentInChildren<Text>();
	}

	void Update() {
		if(SelectedTower == null)
		{
			image.enabled = false;
			price.enabled = false;
		}
		else
		{
			image.enabled = true;
			price.enabled = true;
			price.text = "Price " + SelectedTower.UpgradeCost;
		}

		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

			if (hit.collider != null && hit.collider.tag == "Tower")
			{
				SelectedTower = hit.transform.gameObject.GetComponent<Tower>();
			}
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			SelectedTower = null;
		}
	}

	public void UpgradeTower()
	{
		if (GameManager.Instance.Gold >= SelectedTower.UpgradeCost)
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
