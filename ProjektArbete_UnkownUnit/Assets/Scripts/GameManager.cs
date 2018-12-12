using System.Collections.Generic;
using System.Threading;
using Assets.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameManager : Singleton<GameManager>
    {
        private int gold;

        public TowerBtn Tower { get; set; }
        public Tower selectedTower;

        [SerializeField] private Text goldLabel;
        [SerializeField] private Text lvlLabel;
        [SerializeField] private Text dmgLabel;

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
            this.lvlLabel.enabled = false;
            this.dmgLabel.enabled = false;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Tower")
                    {
                        selectedTower = hit.transform.gameObject.GetComponent<Tower>();
                        this.lvlLabel.enabled = true;
                        this.dmgLabel.enabled = true;
                    }
                }
                else
                {
                    selectedTower = null;
                }
            }

            if (selectedTower != null)
            {
                this.lvlLabel.text = "Level: " + this.selectedTower.Level;
                this.dmgLabel.text = "Damage: " + this.selectedTower.Damage;
            }
            else
            {

                this.lvlLabel.enabled = false;
                this.dmgLabel.enabled = false;
            }

            DropTower();
        }

        public void PickTower(TowerBtn towerBtn)
        {
            if (Gold >= towerBtn.Price)
            {
                this.Tower = towerBtn;
                Hover.Instance.Activate(towerBtn.Sprite);
            }
        }

        public void BuyTower()
        {
            if (Gold >= Tower.Price)
            {
                Gold -= Tower.Price;
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
