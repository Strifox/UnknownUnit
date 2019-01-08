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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
            Debug.Log("Hit");
    }
}
