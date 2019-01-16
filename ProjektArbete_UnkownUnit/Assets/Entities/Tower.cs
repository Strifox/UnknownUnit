using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
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
        public float AttackCooldown;

        public GameObject projectiles;

        private SpriteRenderer mySpriteRenderer;

        public SpriteRenderer SpriteRenderer
        {
            get { return mySpriteRenderer; }
            set { mySpriteRenderer = value; }
        }

        void Start()
        {
            mySpriteRenderer = GetComponent<Tower>().transform.GetChild(0).GetComponent<SpriteRenderer>();
        }

        void Update()
        {

        }


        public void Select()
        {
            mySpriteRenderer.enabled = !mySpriteRenderer.enabled;
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