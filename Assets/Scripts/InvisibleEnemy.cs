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
        if (currentState == EnemyState.attack || currentState == EnemyState.walk)
        {
            
            GameObject.Find("InvisibleWall").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("InvisibleWall").GetComponent<SpriteRenderer>().enabled = true;

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
            if (!playerStats.invisibleEnemy)
            {
                playerStats.increaseStats(gameObject.name);
                GameObject.Find("InvisibleWall").GetComponent<BoxCollider2D>().enabled = false;
                GameObject.Find("InvisibleWall").GetComponent<SpriteRenderer>().enabled = false;

            }
            Destroy(gameObject);
        }
    }
}
