using System.Collections;
using System.Collections.Generic;
using Assets.Entities;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class SellBtn : MonoBehaviour
{
	public Tower SelectedTower;
	private UnityEngine.UI.Image image;
	private Text sellPrice;

	[SerializeField] private Text PaybackText;

	private int payback;

	public int Payback
	{
		get { return payback; }
		set { payback = value; }
	}
	// Use this for initialization
	void Start()
	{
		image = GetComponent<UnityEngine.UI.Image>();
		sellPrice = GetComponentInChildren<Text>();
		Payback = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
			if (hit.collider != null)
			{
				SelectedTower = hit.collider.gameObject.GetComponent<Tower>();
				Payback = this.SelectedTower.TotalCost / 4;
			}
		}

		if (SelectedTower == null)
		{
			image.enabled = false;
			sellPrice.enabled = false;
		}
		else
		{
			image.enabled = true;
			sellPrice.enabled = true;
			var tower = SelectedTower.GetComponent<Tower>();
			payback = tower.TotalCost / 4;
			this.PaybackText.text = "Get: " + payback;
		}
	}

	public void SellTower()
	{
		if (SelectedTower != null)
		{
			GameManager.Instance.Gold += Payback;
			Destroy(this.SelectedTower.gameObject);
			SelectedTower = null;
			Payback = 0;
		}
	}
}
