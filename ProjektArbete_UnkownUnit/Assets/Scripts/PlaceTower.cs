using UnityEngine;

namespace Assets.Scripts
{
    public class PlaceTower : MonoBehaviour
    {
        void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(0))
                PlacingTower();
        }

        void PlacingTower()
        {
            Instantiate(GameManager.Instance.Tower.TowerPrefab, transform.position, Quaternion.identity);
            GameManager.Instance.BuyTower();
        }
    }
}
