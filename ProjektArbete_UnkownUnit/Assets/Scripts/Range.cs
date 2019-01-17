using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Entities;
using Assets.Scripts;
using UnityEngine;

public class Range : Singleton<Range>
{
    private float lastShotTime;
    private float fireRate;

    public List<GameObject> enemiesInRange;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = GetComponentInParent<Tower>().AttackCooldown;
        enemiesInRange = new List<GameObject>();
        lastShotTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = null;

        foreach (GameObject enemy in enemiesInRange)
        {
            target = enemy;
        }

        if (target != null)
        {
            if (Time.time - lastShotTime > fireRate)
            {
                Shoot(target.GetComponent<Collider2D>());
                lastShotTime = Time.time;
            }

            Vector3 direction = gameObject.transform.position - target.transform.position;
            gameObject.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI, new Vector3(0, 0, 1));
        }
    }

    private void Shoot(Collider2D target)
    {
        GameObject projectile = GetComponentInParent<Tower>().projectiles;
        projectile.GetComponent<Projectile>().damage = this.GetComponentInParent<Tower>().Damage;

        Vector3 startPos = gameObject.transform.position;
        Vector3 targetPos = target.transform.position;
        startPos.z = projectile.transform.position.z;
        targetPos.z = projectile.transform.position.z;

        GameObject newProjectile = (GameObject) Instantiate(projectile);
        newProjectile.transform.position = startPos;
        Projectile projectileComp = newProjectile.GetComponent<Projectile>();
        projectileComp.target = target.gameObject;
        projectileComp.startPos = startPos;
        projectileComp.targetPos = targetPos;

        Animator animator = transform.GetComponentInParent<Animator>();
        animator.SetTrigger("fireShot");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            enemiesInRange.Add(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            enemiesInRange.Remove(other.gameObject);
    }
}
