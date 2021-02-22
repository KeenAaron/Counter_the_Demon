using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInescapable : Log
{
    // Start is called before the first frame update
    public float timer;
    public GameObject misil;
    // Update is called once per frame
    void Update()
    {
        if(currentState == EnemyState.attack) {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                InescapableProjectile inescapableProjectile = Instantiate(misil, transform.position, Quaternion.identity).GetComponent<InescapableProjectile>();
                timer = 5f;
            }
        }
    }
}
