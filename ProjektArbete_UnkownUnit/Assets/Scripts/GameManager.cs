using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameManager : Singleton<GameManager>
    {
        private int gold;

        public TowerBtn SelectedTower { get; set; }

        [SerializeField]
        private Text goldLabel;

        public int Gold
        {
            get { return gold; }
            set
            {
                this.gold = value;
                this.goldLabel.text = "Gold: " + value;
            }
        }

        void Start()
        {
            Gold = 1000;
        }

        void Update()
        {
            DropTower();
        }

        public void PickTower(TowerBtn towerBtn)
        {
            if (Gold >= towerBtn.Price)
            {
                this.SelectedTower = towerBtn;
                Hover.Instance.Activate(towerBtn.Sprite);
            }
        }

        public void BuyTower()
        {
            if (Gold >= SelectedTower.Price)
            {
                Gold -= SelectedTower.Price;
                Hover.Instance.Deactivate();
            }
        }

        private void DropTower()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Hover.Instance.Deactivate();
        }
    }

}
