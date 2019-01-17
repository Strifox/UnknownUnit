using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOverButton : MonoBehaviour {
	public GameObject PlayButton;
	public Sprite PlayButtonSprite;
	public Sprite PlayButtonSpriteInFocus;

	public GameObject HighscoreButton;
	public Sprite HighscoreButtonSprite;
	public Sprite HighscoreButtonSpriteInFocus;

	public GameObject CreditsButton;
	public Sprite CreditsButtonSprite;
	public Sprite CreditsButtonSpriteInFocus;

	public GameObject ExitButton;
	public Sprite ExitButtonSprite;
	public Sprite ExitButtonSpriteInFocus;

	private SpriteRenderer PlaySpriteRenderer;
	private SpriteRenderer HighscoreSpriteRenderer;
	private SpriteRenderer CreditsSpriteRenderer;
	private SpriteRenderer ExitSpriteRenderer;

	void Start()
	{
		PlaySpriteRenderer = PlayButton.GetComponent<SpriteRenderer>();
		HighscoreSpriteRenderer = HighscoreButton.GetComponent<SpriteRenderer>();
		CreditsSpriteRenderer = CreditsButton.GetComponent<SpriteRenderer>();
		ExitSpriteRenderer = ExitButton.GetComponent<SpriteRenderer>();
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
					PlaySpriteRenderer.sprite = PlayButtonSpriteInFocus;
					break;
				case "HighscoreButton":
					HighscoreSpriteRenderer.sprite = HighscoreButtonSpriteInFocus;
					break;
				case "CreditsButton":
					CreditsSpriteRenderer.sprite = CreditsButtonSpriteInFocus;
					break;
				case "ExitButton":
					ExitSpriteRenderer.sprite = ExitButtonSpriteInFocus;
					break;
				default:
					break;
			}
		}
		else
		{
			PlaySpriteRenderer.sprite = PlayButtonSprite;
			HighscoreSpriteRenderer.sprite = HighscoreButtonSprite;
			CreditsSpriteRenderer.sprite = CreditsButtonSprite;
			ExitSpriteRenderer.sprite = ExitButtonSprite;
		}
	}
}
