using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot : MonoBehaviour
{

    private Animator anim;
    public GameObject recover;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Cuando la hitbox alcanza la colliderBox del objecto:
    public void Smash()
    {
        anim.SetBool("smash", true);
        StartCoroutine(breakCo());
    }

    // Elimina el objeto una vez se ha roto
    IEnumerator breakCo()
    {
        yield return new WaitForSeconds(.3f);
        RecoverHealth invoc = Instantiate(recover, transform.position, Quaternion.identity).GetComponent<RecoverHealth>();
        this.gameObject.SetActive(false);
    }
}
