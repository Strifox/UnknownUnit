using System.Collections;
using System.Collections.Generic;
using Assets.Entities;
using UnityEngine;

public class Range : MonoBehaviour
{


    private Enemy _targetEnemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_targetEnemy);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Witch"))
            _targetEnemy = other.gameObject.GetComponentInChildren<Enemy>();
    }
}
