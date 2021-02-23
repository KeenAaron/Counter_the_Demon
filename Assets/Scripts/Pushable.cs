﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    public float hit;
    public float moveTime;
    public float damage;

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("push"))
        {
            CircleCollider2D push = other.GetComponent<CircleCollider2D>();
            Rigidbody2D pushable = GetComponent<Rigidbody2D>();
            if (pushable != null)
            {
                
                pushable.isKinematic = false;
                pushable.gravityScale = 0;
                Vector2 difference = transform.position - push.transform.position;
                difference = difference.normalized * hit;
                pushable.AddForce(difference, ForceMode2D.Impulse);

                if (pushable.CompareTag("enemy")) {
                    pushable.GetComponent<Enemy>().currentState = EnemyState.stagger;
                }
                

                StartCoroutine(PushCo(pushable));      
            }
        }

        /*if (other.CompareTag("Player")) {
            Rigidbody2D pushable = GetComponent<Rigidbody2D>();
            if (other.GetComponent<PlayerMovment>().currentState != PlayerState.stagger)
            {
                pushable.GetComponent<PlayerMovment>().currentState = PlayerState.stagger;
                other.GetComponent<PlayerMovment>().KnockCo(moveTime);
            }
        }*/

       
        if (other.CompareTag("Player"))
        {

            Rigidbody2D pushable = other.GetComponent<Rigidbody2D>();
            Rigidbody2D push = this.GetComponent<Rigidbody2D>();

            if (other.GetComponent<PlayerMovment>().currentState != PlayerState.stagger)
            {
                if (pushable != null)
                {
                    pushable.isKinematic = false;
                    Vector2 difference = pushable.transform.position - push.transform.position;
                    difference = difference.normalized * hit;
                    pushable.AddForce(difference, ForceMode2D.Impulse);

                    push.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    pushable.GetComponent<PlayerMovment>().currentState = PlayerState.stagger;
                    other.GetComponent<PlayerMovment>().KnockCo(moveTime, damage);

                    StartCoroutine(PushCo(pushable));
                    StartCoroutine(PushCo(push));
                }
            }
        }
    }

    private IEnumerator PushCo(Rigidbody2D pushable)
    {
        if (pushable != null)
        {
            yield return new WaitForSeconds(moveTime);
            pushable.velocity = Vector2.zero;
            if (pushable.CompareTag("enemy"))
            {
                pushable.GetComponent<Enemy>().currentState = EnemyState.idle;
            }
            if (pushable.CompareTag("Player"))
            {
                pushable.GetComponent<PlayerMovment>().currentState = PlayerState.walk;
            }
            if (!pushable.CompareTag("enemy") && !pushable.CompareTag("Player"))
            {
                pushable.isKinematic = true;
            }
        }
    }
}
