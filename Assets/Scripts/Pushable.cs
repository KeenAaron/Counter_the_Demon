using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    public float hit;
    public float moveTime;

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("push"))
        {
            CircleCollider2D push = other.GetComponent<CircleCollider2D>();
            Rigidbody2D pushable = GetComponent<Rigidbody2D>();
            if (pushable != null)
            {
                if (pushable.CompareTag("enemy")) {
                    pushable.GetComponent<Enemy>().currentState = EnemyState.stagger;
                }
                pushable.isKinematic = false;
                pushable.gravityScale = 0;
                Vector2 difference = transform.position - push.transform.position;
                difference = difference.normalized * hit;
                pushable.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(PushCo(pushable));      
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
            if (!pushable.CompareTag("enemy"))
            {
                pushable.isKinematic = true;
            }
        }
    }
}
