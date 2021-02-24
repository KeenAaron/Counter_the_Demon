using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverHealth : MonoBehaviour
{
    public Stats playerStats;
    public Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        playerStats = GameObject.FindWithTag("stats").GetComponent<Stats>();
    }
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //playerStats = GameObject.FindWithTag("Player").GetComponent<Stats>();
            playerStats.recoverHealth();
            Destroy(this.gameObject);
        }

    }
}
