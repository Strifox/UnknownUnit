using UnityEngine;

namespace Assets.Scripts
{
	public class PlaceTower : MonoBehaviour
	{
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
				PlacingTower();
		}

		private void PlacingTower()
		{
			if(GameManager.Instance.Tower != null)
			{
				Instantiate(GameManager.Instance.Tower.TowerPrefab, transform.position, Quaternion.identity);
				GameManager.Instance.BuyTower();
			}
		}
	}
}
