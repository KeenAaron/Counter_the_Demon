using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InescapableProjectile : MonoBehaviour
{
    public Transform target;
    public int moveSpeed;
    protected Rigidbody2D myRigidbody;


    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        myRigidbody.MovePosition(temp);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("shield") || other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }

    }
}
