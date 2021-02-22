using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{

    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;


    // Start is called before the first frame update
    protected void Awake()
    {
        health = maxHealth.initialValue;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("attack"))
        {
            float damage = other.GetComponent<PlayerHit>().damage;

            if (gameObject != null)
            {
                TakeDamage(damage);
            }
        }
    }

    protected virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void changeState()
    {
        StartCoroutine(changeStateCo());
    }

    public virtual IEnumerator changeStateCo()
    {
        currentState = EnemyState.stagger;
        yield return new WaitForSeconds(1.5f);
        currentState = EnemyState.idle;
    }
}
