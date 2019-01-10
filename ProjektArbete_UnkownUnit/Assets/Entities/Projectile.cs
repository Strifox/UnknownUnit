using Assets.Scripts;
using UnityEngine;

namespace Assets.Entities
{
    public class Projectile : MonoBehaviour {
        
        public Debuff Debuff;   
        
        public float speed = 10;
        public int damage;
        public GameObject target;
        public Vector3 startPos;
        public Vector3 targetPos;

        private float startTime;
        private float distance;

        void Start ()
        {
            damage = Tower.Instance.Damage;
            startTime = Time.time;
            distance = Vector2.Distance(startPos, targetPos);
        }
	
        void Update ()
        {
            float timeInterval = Time.time - startTime;
            gameObject.transform.position = Vector3.Lerp(startPos, targetPos, timeInterval * speed / distance);

            if (gameObject.transform.position.Equals(targetPos))
            {
                if (target != null)
                {
                    Transform healthBarTransform = target.transform.Find("HealthBar");
                    HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
                    healthBar.currentHealth -= Mathf.Max(damage, 0);

                    if (healthBar.currentHealth <= 0)
                    {
                        Destroy(target.transform.parent.gameObject);
                        GameManager.Instance.Gold += 30;
                    }
                }
                Destroy(gameObject);
            }
        }
    }
}
