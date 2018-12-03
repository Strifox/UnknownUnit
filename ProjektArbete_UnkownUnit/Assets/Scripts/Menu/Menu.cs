using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
			if (hit.collider != null)
			{
				switch(hit.collider.tag)
				{
					case "PlayButton":
						SceneManager.LoadScene(1);
						break;
					case "HighscoreButton":
						SceneManager.LoadScene(2);
						break;
					case "CreditsButton":
						SceneManager.LoadScene(3);
						break;
					case "ExitButton":
						Application.Quit();
						break;
					default:
						break;
				}
			}
		}
	}
}
