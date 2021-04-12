using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushActivate : MonoBehaviour
{
    // Start is called before the first frame update
    public Stats playerStats;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "pushable1" && gameObject.name == "fire1")
        {
            playerStats.setPushables();
            Destroy(other.gameObject, 0.2f);
            Destroy(gameObject, 0.5f);
        } else if (other.name == "pushable2" && gameObject.name == "fire2")
        {
            playerStats.setPushables();
            Destroy(other.gameObject, 0.2f);
            Destroy(gameObject, 0.5f);
        } else if (other.name == "pushable3" && gameObject.name == "fire3")
        {
            playerStats.setPushables();
            Destroy(other.gameObject, 0.2f);
            Destroy(gameObject, 0.5f);
        }
    }
}
