using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleEnemy : Log
{
    public bool invisible = true;
    public Stats playerStats;
    public float timer;

    void Update()
    
    {
        timer -= Time.deltaTime;
        ChangeVisibility();
        if (timer <= 0)
        {
            if (invisible)
            {
                invisible = false;
                timer = 10f;
            }
            else
            {
                invisible = true;
                timer = 10f;
            }
        }
    }

    /*IEnumerator Invisble()
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
    }*/

    public void ChangeVisibility()
    {
        if (invisible)
        {
            GetComponent<Renderer>().enabled = false;
        }
        else
        {
            GetComponent<Renderer>().enabled = true;
        }
    }

    protected override void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            playerStats.increaseStats();
        }
    }
}
