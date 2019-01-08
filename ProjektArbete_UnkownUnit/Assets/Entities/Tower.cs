using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Entities
{
    public class Tower : Singleton<Tower>
    {
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

        void Start()
        {
            mySpriteRenderer = GetComponent<Tower>().transform.GetChild(0).GetComponent<SpriteRenderer>();
        }

        void Update()
        {
        }


        public void Select(Tower tower)
        {
            if (tower != null)
                mySpriteRenderer.enabled = !mySpriteRenderer.enabled;
        }

        //public void DeSelect(Tower tower)
        //{
        //    mySpriteRenderer.enabled = false;
        //}


    }

    public enum TowerType
    {
        Damage,
        Poison,
        Slow,
        AreaOfEffect
    }
}