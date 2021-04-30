using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInescapable : Log
{
    // Start is called before the first frame update
    public float timer;
    public GameObject misil;
    public Stats playerStats;
    // Update is called once per frame
    void Update()
    {
        if(currentState == EnemyState.attack || currentState == EnemyState.walk) {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                InescapableProjectile inescapableProjectile = Instantiate(misil, transform.position, Quaternion.identity).GetComponent<InescapableProjectile>();
                timer = 5f;
            }
        }
    }

    protected override void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (!playerStats.inescapableEnemy)
            {
                playerStats.increaseStats(gameObject.name);
            }
            Destroy(gameObject);
        }
    }
}
