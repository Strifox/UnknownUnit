using System.Collections;
using System.Collections.Generic;
using Assets.Entities;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    public float currentHealth;
    public float maxHealth;
    public float percentHealth;
    public float currentHealthX;
    private float originalScale;

    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
        maxHealth = GetComponentInParent<Enemy>().HP;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        percentHealth = (currentHealth / maxHealth);
        currentHealthX = Mathf.Lerp(0, 1, percentHealth);
        transform.localScale = new Vector3(currentHealthX, 1);
    }

    private void SetSize()
    {
        bar.localScale = new Vector3(1f, 1f);
    }
}
