using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderDestroy : MonoBehaviour
{
    public Stats playerStats;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("attack"))
        {
            switch (gameObject.name)
            {
                case "destroyable1":
                    playerStats.setDestroyables();
                    gameObject.GetComponent<Pot>().Smash();
                    break;
                case "destroyable2":
                    if (playerStats.getDestroyables() == 1)
                    {
                        playerStats.setDestroyables();
                        gameObject.GetComponent<Pot>().Smash();
                    }
                    break;
                default:
                    if (playerStats.getDestroyables() == 2)
                    {
                        playerStats.invocationAbility();
                        gameObject.GetComponent<Pot>().Smash();
                    }
                    break;
            }
        }
    }
}
