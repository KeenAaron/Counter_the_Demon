using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : Log
{
    // Start is called before the first frame update
    public bool invisible;
    public bool berserker;
    public bool trhow;

    public float timer;
    public SpriteRenderer spriteRenderer;
    public GameObject misil;
    public Stats playerStats;
    protected override void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //video 18
        target = GameObject.FindWithTag("Player").transform;
        invisible = false;
        berserker = false;
        trhow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == EnemyState.attack || currentState == EnemyState.walk)
        {
            timer -= Time.deltaTime;
            ChangeStat();
            ChangeVisibility();
            if (timer <= 0)
            {
                if (berserker)
                {
                    berserker = false;
                    timer = 10f;
                }
                else if (trhow)
                {
                    InescapableProjectile inescapableProjectile = Instantiate(misil, transform.position, Quaternion.identity).GetComponent<InescapableProjectile>();
                    timer = 5f;
                } else if (invisible)
                {
                    invisible = false;
                    timer = 10f;
                } else
                {
                    timer = 10f;
                }
                randomState();
            }
        }
    }

    public void randomState()
    {
        int num = Random.Range(0, 3);

        switch (num)
        {
            case 0:
                berserker = true;
                break;
            case 1:
                trhow = true;
                break;
            case 2:
                invisible = true;
                break;
            default:
                invisible = false;
                berserker = false;
                trhow = false;
                break;
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

    public void ChangeVisibility()
    {
        if (invisible)
        {
            GetComponent<Renderer>().enabled = false;
        }
        else
        {
            GetComponent<Renderer>().enabled = true;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("attack"))
        {
            float damage = other.GetComponent<PlayerHit>().damage;

            if (gameObject != null)
            {
                if (berserker)
                {
                    TakeDamage(damage / 2);
                }
                else
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
            Destroy(gameObject);
            playerStats.increaseStats();
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
        }
        else
        {
            currentState = EnemyState.stagger;
            yield return new WaitForSeconds(1.5f);
        }
        currentState = EnemyState.idle;
    }
}
