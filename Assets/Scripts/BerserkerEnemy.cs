using System.Collections;
using UnityEngine;

public class BerserkerEnemy : Log
{
    // Start is called before the first frame update
    public bool berserker;
    public Stats playerStats;
    public float timer;
    public SpriteRenderer spriteRenderer;

    protected override void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //video 18
        target = GameObject.FindWithTag("Player").transform;
        berserker = false;

    }

    void Update()
    {
        ChangeStat();
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (berserker)
            {
                berserker = false;
                timer = 10f;
            }
            else
            {
                berserker = true;
                timer = 10f;
            }
        }
    }

    public void ChangeStat()
    {
        if (berserker)
        {
            spriteRenderer.color = new Color(1f, 0f, 0f, 1f);
            baseAttack = 2;
            moveSpeed = 3;
        }
        else
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            baseAttack = 1;
            moveSpeed = 1.5f;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("attack"))
        {
            float damage = other.GetComponent<PlayerHit>().damage;

            if (gameObject != null)
            {
                if (berserker) {
                    TakeDamage(damage / 2);
                } else
                {
                    TakeDamage(damage);
                }
            }
        }
    }

    protected override void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (!playerStats.berserkerEnemy)
            {
                playerStats.increaseStats(gameObject.name);
            }
            Destroy(gameObject);
        }
    }

    public override IEnumerator changeStateCo()
    {
        if (berserker)
        {
            berserker = false;
            timer = 10f;
            currentState = EnemyState.stagger;
            yield return new WaitForSeconds(0.75f);
        } else
        {
            currentState = EnemyState.stagger;
            yield return new WaitForSeconds(1.5f);
        }
        currentState = EnemyState.idle;
    }
}
