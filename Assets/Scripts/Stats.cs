using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public PlayerHit hitUp;
    public PlayerHit hitLeft;
    public PlayerHit hitRight;
    public PlayerHit hitDown;
    public PlayerMovment player;
    public HeartManager heart;


    public void increaseStats()
    {
        hitUp.increaseDamage();
        hitLeft.increaseDamage();
        hitRight.increaseDamage();
        hitDown.increaseDamage();
        player.increaseSpeed();
        player.hearthContainers.setHeartContainer();
        player.currentHealth.setPlayerHealth();
        heart.InitHearts();
        heart.UpdateHearts();
    }

    public void recoverHealth()
    {
        player.currentHealth.recoverPlayerHealth();
        heart.InitHearts();
        heart.UpdateHearts();
    }
}
