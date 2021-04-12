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
    public int objectives;
    public int destroyables;
    public int pushables;

    private void Start()
    {
        objectives = 0;
        destroyables = 0;
        pushables = 0;
    }

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

    public void setObjectives()
    {
        objectives++;
        shieldAbility();
    }

    public void shieldAbility()
    {
        if (objectives == 3)
        {
            player.setUseShield();
        }
    }

    public int getDestroyables()
    {
        return destroyables;
    }

    public void setDestroyables()
    {
        destroyables++;
    }

    public void invocationAbility()
    {
        player.setUseInvocation();
    }

    public void setPushables()
    {
        pushables++;
        shockAbility();
    }

    public void shockAbility()
    {
        if (pushables == 3)
        {
            player.setUseShock();
        }
    }
}
