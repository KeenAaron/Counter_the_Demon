using System.IO;

using System.Diagnostics;
using System.IO.Pipes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//hereda de Enemy ja que es un tipus d'enemic
public class Log : Enemy
{
    protected Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //video 18
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        CheckDistance();
    }

    protected void CheckDistance()
    {
        if (Vector3.Distance(target.position, 
                             transform.position) <= chaseRadius 
            && Vector3.Distance(target.position, transform.position) > attackRadius)
        
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true); 
            }
        }else{
            anim.SetBool("wakeUp", false);
        }
    }


    protected void changeAnim(Vector2 direction)
    {
        direction = direction.normalized;
        anim.SetFloat("moveX", direction.x);
        anim.SetFloat("moveY", direction.y);
    }

    protected void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
