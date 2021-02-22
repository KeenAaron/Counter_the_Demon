using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricShock : Arrow
{
    public Enemy enemy;

    // Update is called once per frame
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("shield"))
        {
            if(other.gameObject.CompareTag("enemy"))
            {
                enemy = other.gameObject.GetComponent<Enemy>();
                enemy.changeState();
            }
            Destroy(this.gameObject);
        }
    }
}
