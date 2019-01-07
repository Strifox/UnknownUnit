using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Entities
{
    public class Tower : Singleton<Tower> {
        public TowerType TowerType;
        public string Name;
        public int Damage;
        public float Range;
        public int HP;
        public int Level;
        public string Description;
        public int BaseCost;
        public int UpgradeCost;
        public int TotalCost;
        public int AttackCooldown;

        public List<Projectile> projectiles;

        private SpriteRenderer mySpriteRenderer;
        private Enemy targetEnemy;
        private Queue<Enemy> enemies = new Queue<Enemy>();

        void Start()
        {
            mySpriteRenderer = GetComponent<Tower>().transform.GetChild(0).GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            Debug.Log(targetEnemy);
        }


        public void Select()
        {
            mySpriteRenderer.enabled = true;
        }

        public void DeSelect()
        {
            mySpriteRenderer.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Witch"))
            {
                enemies.Enqueue(other.GetComponent<Enemy>());
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Witch"))
                targetEnemy = null;
        }
    }

		public enum TowerType
		{
					Damage,
					Poison,
					Slow,
					AreaOfEffect
		}
}