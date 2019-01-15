using System.Collections.Generic;
using System.Threading;
using Assets.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameManager : Singleton<GameManager>
    {
        private int gold;
        private int wave;
        private int health;

        public bool gameOver = false;
        public TowerBtn TowerBtn { get; set; }
        public Tower selectedTower;

        [SerializeField] private Text goldLabel;
        [SerializeField] private Text lvlLabel;
        [SerializeField] private Text dmgLabel;
        [SerializeField] private Text healthLabel;
        [SerializeField] private Text waveLabel;

        public int Gold
        {
            get { return gold; }
            set
            {
                this.gold = value;
                this.goldLabel.text = "Gold: " + value;
            }
        }

        public int Wave
        {
            get { return wave; }
            set
            {
                this.wave = value;
                if (!gameOver)
                {
                    this.waveLabel.text = "Wave: " + (wave + 1);
                }
            }
        }

        public int Health
        {
            get { return health; }
            set
            {
                this.health = value;
                this.healthLabel.text = "Health: " + value;
            }
        }

        void Start()
        {
            Wave = 0;
            Health = 100;
            Gold = 1000;
            this.waveLabel.enabled = true;
            this.healthLabel.enabled = true;
            this.lvlLabel.enabled = false;
            this.dmgLabel.enabled = false;
        }

        void Update()
        {
            if (Health <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }

            SelectTower();

            EnableLabel();

            DropTower();
        }

        public void PickTower(TowerBtn towerBtn)
        {
            if (Gold >= towerBtn.Price)
            {
                this.TowerBtn = towerBtn;
                Hover.Instance.Activate(towerBtn.Sprite);
            }
        }

        public void BuyTower()
        {
            if (Gold >= TowerBtn.Price)
            {
                Gold -= TowerBtn.Price;
            }
        }

        private void SelectTower()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("Tower"))
                    {
                        selectedTower = hit.transform.gameObject.GetComponent<Tower>();
                        this.selectedTower.Select(selectedTower);
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

        private void EnableLabel()
        {
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
        }

        private void DropTower()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Hover.Instance.Deactivate();
        }
    }
}

