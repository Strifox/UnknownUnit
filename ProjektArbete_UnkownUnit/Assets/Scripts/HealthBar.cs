using System.Collections;
using System.Collections.Generic;
using Assets.Entities;
using UnityEngine;

public class HealthBar : MonoBehaviour
{ 
    public float currentHealth;
    public float maxHealth;
    private float originalScale;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = GetComponentInParent<Enemy>().HP;
        currentHealth = maxHealth;
        originalScale = gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x = currentHealth / maxHealth * originalScale;
        gameObject.transform.localScale = tmpScale;
    }
}
