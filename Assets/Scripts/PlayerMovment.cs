using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    walk,
    attack,
    push,
    interact,
    stagger,
    idle
}


public class PlayerMovment : MonoBehaviour
{
    public PlayerState currentState; //lestat en el que es troba el player
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    private float habilityTimer;
    private bool useHability = true;
    private bool useShield = false;
    private bool useInvocation = false;
    public bool useShock = false;
    public FloatValue currentHealth;
    public FloatValue hearthContainers;

    public SignalSender playerHealthSignal;

    public GameObject projectile;
    public GameObject invocation;
    public GameObject shield;
    public GameObject electric;


    private CircleCollider2D pushCollider;

    void Start()
    {
        currentState = PlayerState.walk; //cambia l'estat a caminar
        animator = GetComponent<Animator>(); //crida a animator per actualitzar la animacio
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);

        pushCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!useHability)
        {
            habilityTimer -= Time.deltaTime;
            if (habilityTimer <= 0)
            {
                useHability = true;
            }
        }

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("attack"))
        {
            if (currentState != PlayerState.attack && currentState != PlayerState.push && currentState != PlayerState.stagger)
            {
                StartCoroutine(AttackCo());
            }
        }
        else if (Input.GetButtonDown("Second Weapon"))
        {
            if (currentState != PlayerState.attack && currentState != PlayerState.push)
            {
                StartCoroutine(SecondAttackCo());
            }
        } else if (Input.GetButtonDown("push"))
        {
            if (currentState != PlayerState.attack && currentState != PlayerState.push)
            {
                StartCoroutine(PushCo());
            }
        }
        else if (Input.GetButtonDown("invocation"))
        {
            if (currentState != PlayerState.attack && currentState != PlayerState.push && useHability && useInvocation)
            {
                habilityTimer = 10f;
                useHability = false;
                StartCoroutine(InvocationCo());
            }
        }
        else if (Input.GetButtonDown("shield"))
        {
            if (currentState != PlayerState.attack && currentState != PlayerState.push && useHability && useShield)
            {
                habilityTimer = 5f;
                useHability = false;
                StartCoroutine(ShieldCo());
            }
        }
        else if (Input.GetButtonDown("electric"))
        {
            if (currentState != PlayerState.attack && currentState != PlayerState.push && useHability && useShock)
            {
                habilityTimer = 3f;
                useHability = false;
                StartCoroutine(ElectricCo());
            }
        }
        else if (currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    private IEnumerator PushCo()
    {
        animator.SetBool("pushing", true);
        currentState = PlayerState.push;
        yield return null;
        animator.SetBool("pushing", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    private IEnumerator SecondAttackCo()
    {
        currentState = PlayerState.attack;
        yield return null;
        MakeArrow();
        animator.SetBool("moving", false);
        yield return new WaitForSeconds(1f);
        currentState = PlayerState.walk;
    }

    private IEnumerator InvocationCo()
    {
        currentState = PlayerState.attack;
        animator.SetBool("moving", false);
        yield return new WaitForSeconds(.75f);
        MakeInvocation();
        yield return new WaitForSeconds(1.25f);
        currentState = PlayerState.walk;
    }

    private IEnumerator ShieldCo()
    {
        currentState = PlayerState.attack;
        yield return null;
        MakeShield();
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    private IEnumerator ElectricCo()
    {
        currentState = PlayerState.attack;
        yield return null;
        MakeElectric();
        animator.SetBool("moving", false);
        yield return new WaitForSeconds(1.5f);
        currentState = PlayerState.walk;
    }

    private void MakeArrow()
    {
        Vector2 temp = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        Arrow arrow = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Arrow>();
        arrow.Setup(temp, ChooseArrowDirectrion());
    }


    private void MakeInvocation()
    {
        Invocation invoc = Instantiate(invocation, transform.position, Quaternion.identity).GetComponent<Invocation>();
    }

    private void MakeShield()
    {
        Shield shiel = Instantiate(shield, transform.position, Quaternion.identity).GetComponent<Shield>();
    }

    private void MakeElectric()
    {
        Vector2 temp = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        electricShock electricShock = Instantiate(electric, transform.position, Quaternion.identity).GetComponent<electricShock>();
        electricShock.Setup(temp, ChooseArrowDirectrion());
    }

    Vector3 ChooseArrowDirectrion()
    {
        float temp = Mathf.Atan2(animator.GetFloat("moveY"), animator.GetFloat("moveX")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
            pushCollider.offset = new Vector2(change.x / 2, change.y / 2);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        change.Normalize(); //aixi en diagonal no es mou el doble de rapid
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }

    public void increaseSpeed()
    {
        speed += 2;
    }

    public void Knock(float moveTime, float damage)
    {
        currentHealth.RuntimeValue -= damage;

        if (currentHealth.RuntimeValue > 0)
        {
            playerHealthSignal.Raise();
            StartCoroutine(KnockCo(moveTime, damage));
        } else {
            this.gameObject.SetActive(false);
        }
    }

    public IEnumerator KnockCo(float moveTime, float damage)
    {
        if(myRigidbody != null)
        {
            yield return new WaitForSeconds(moveTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }

    public void setUseShield()
    {
        useShield = true;
    }

    public void setUseInvocation()
    {
        useInvocation = true;
    }

    public void setUseShock()
    {
        useShock = true;
    }
}
