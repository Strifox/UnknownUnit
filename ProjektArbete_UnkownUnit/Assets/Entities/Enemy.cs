using System.Collections.Generic;
using UnityEngine;

namespace Assets.Entities
{
    public class Enemy : MonoBehaviour {
        public string Name;
        public int HP;
        public int Damage;
        public int MovementSpeed;

        public List<Debuff> debuffs;

        void Start () {
		
        }
	
        void Update () {
		
        }
    }
}
