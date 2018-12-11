using Assets.Entities;
using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class UpgradeBtn : MonoBehaviour {

	public GameObject SelectedTower;
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
			var tower = SelectedTower.GetComponent<Tower>();
			price.text = "Price " + tower.UpgradeCost;
		}

		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

			if (hit.collider != null && (hit.collider.tag == "Tower" || hit.collider.tag == "UI"))
			{
				SelectedTower = hit.transform.gameObject;
			}
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			SelectedTower = null;
		}
	}

	public void UpgradeTower()
	{
		var tower = SelectedTower.GetComponent<Tower>();
		if (GameManager.Instance.Gold >= tower.UpgradeCost)
		{
			tower.Damage += 20;
			tower.Level++;
			var preUpgradeCost = tower.UpgradeCost;
			tower.UpgradeCost += 20;
			tower.TotalCost += preUpgradeCost;
			GameManager.Instance.Gold -= preUpgradeCost;
		}
	}
}
