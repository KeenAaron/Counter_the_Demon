using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Invocation : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float timeToDestroy = 10f;
    public int moveSpeed;
    float distanceToClosestEnemy;
    Enemy closestEnemy;
    Enemy[] allEnemies;

    void Start()
    {
        target = GameObject.FindObjectOfType<PlayerMovment>().transform;
        myRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        Destroy(this.gameObject, timeToDestroy);
        if (closestEnemy == null)
        {
            followPlayer();
        }

        findClosestEnemy();
    }

    public void findClosestEnemy()
    {
        distanceToClosestEnemy = 8;
        closestEnemy = null;
        allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
                target = closestEnemy.transform;
                CheckDistance();
            }
        }

        Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
    }

    public void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius)

        {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                myRigidbody.MovePosition(temp);
        }
    }

    protected void followPlayer()
    {
        target = GameObject.FindObjectOfType<PlayerMovment>().transform;
        Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        myRigidbody.MovePosition(temp);
        Debug.DrawLine(this.transform.position, target.position);
    }

}

