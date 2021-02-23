using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : Log
{
    public bool invisible = true;
    public Stats playerStats;

    void Update()
    
    {
        if (invisible) 
        {
            StartCoroutine(Invisble());
        } else
        {
            StartCoroutine(Visble());
        }
    }

    IEnumerator Invisble()
    {
        yield return new WaitForSeconds(10);
        GetComponent<Renderer>().enabled = false;
        invisible = false;

    }

    IEnumerator Visble()
    {
        yield return new WaitForSeconds(10);
        GetComponent<Renderer>().enabled = true;
        invisible = true;
    }

    protected override void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            playerStats.increaseStats();
            Destroy(gameObject);
        }
    }
}
