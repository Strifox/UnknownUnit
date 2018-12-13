using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TowerBtn : MonoBehaviour
    {
        [SerializeField]
        private GameObject towerPrefab;
        public GameObject TowerPrefab
        {
            get { return towerPrefab; }
        }

        [SerializeField]
        private Text TowerPrice;

        [SerializeField]
        private Sprite sprite;
        public Sprite Sprite
        {
            get { return sprite; }
        }

        [SerializeField]
        private int price;
        public int Price
        {
            get { return price; }
        }

        private void Start()
        {
           // TowerPrice.text = "Price: " + price;
        }

       

    }
}
