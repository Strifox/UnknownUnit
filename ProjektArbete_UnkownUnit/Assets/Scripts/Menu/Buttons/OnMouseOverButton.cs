using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOverButton : MonoBehaviour {
	public Sprite sprite;
	public Sprite spriteInFocus;

	private SpriteRenderer spriteRenderer;

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

		RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

		if (hit.collider != null)
		{
			switch (hit.collider.tag)
			{
				case "PlayButton":
					var playButton = this.GetComponent<SpriteRenderer>();
					playButton.sprite = spriteInFocus;
					break;
				case "ExitButton":
					break;
				default:
					break;
			}
		}
		else
		{
			this.spriteRenderer.sprite = sprite;
		}
	}
}
