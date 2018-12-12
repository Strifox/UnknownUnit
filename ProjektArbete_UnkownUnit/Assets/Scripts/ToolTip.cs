using System.Collections;
using System.Collections.Generic;
using Assets.Entities;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
	public GameObject SelectedTower;
	private UnityEngine.UI.Image image;
	private RectTransform position;
	[SerializeField]
	private Text toolTiptText;

	void Start()
	{
		image = GetComponent<UnityEngine.UI.Image>();
		image.enabled = false;
		toolTiptText.enabled = false;
		position = GetComponent<RectTransform>();
	}

	void Update()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

		RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

		if (hit.collider != null && hit.collider.tag == "Button")
		{
			this.SelectedTower = hit.collider.gameObject;
			Invoke("ShowToolTip", 0.5f);
		}
		else
		{
			this.SelectedTower = null;
		}

		if (Input.GetMouseButtonDown(0))
		{
			SelectedTower = null;
		}
	}

	public void ShowToolTip()
	{
		if (SelectedTower == null)
		{
			image.enabled = false;
			toolTiptText.enabled = false;
		}
		else
		{
			position.position = new Vector3(SelectedTower.transform.position.x, SelectedTower.transform.position.y + 3.26f, SelectedTower.transform.position.z);
			image.enabled = true;
			toolTiptText.enabled = true;
			toolTiptText.text = "Name: " + SelectedTower.GetComponent<TowerBtn>().TowerPrefab.GetComponent<Tower>().Name + "\n" +
					"Damage: " + SelectedTower.GetComponent<TowerBtn>().TowerPrefab.GetComponent<Tower>().Damage + "\n" +
					"Description: " + SelectedTower.GetComponent<TowerBtn>().TowerPrefab.GetComponent<Tower>().Description;
		}
	}
}
