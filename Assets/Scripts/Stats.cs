using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public PlayerHit hitUp;
    public PlayerHit hitLeft;
    public PlayerHit hitRight;
    public PlayerHit hitDown;
    public PlayerMovment playerSpeed;


    public void increaseStats()
    {
        hitUp.increaseDamage();
        hitLeft.increaseDamage();
        hitRight.increaseDamage();
        hitDown.increaseDamage();
        playerSpeed.increaseSpeed();
    }
}
