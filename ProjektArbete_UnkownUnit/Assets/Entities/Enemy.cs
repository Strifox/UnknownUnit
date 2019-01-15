using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

namespace Assets.Entities
{
    public class Enemy : MonoBehaviour
    {
        public string Name;
        public int HP;
        public int Damage;
        public int MovementSpeed;

        public List<Debuff> debuffs;

        void Start () {
		
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Target"))
            {
                GameManager.Instance.Health = GameManager.Instance.Health - Damage;
            }
        }
    }
}

        void Start()
        {

        }

        void Update()
        {
