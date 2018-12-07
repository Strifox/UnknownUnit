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
            Instantiate(GameManager.Instance.SelectedTower.TowerPrefab, transform.position, Quaternion.identity);
            GameManager.Instance.BuyTower();
        }
    }
}
