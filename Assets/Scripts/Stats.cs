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
    public bool puzzle1;
    public bool puzzle2;
    public bool puzzle3;
    public bool berserkerEnemy;
    public bool invisibleEnemy;
    public bool inescapableEnemy;

    public void increaseStats(string enemy)
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

        switch (enemy)
        {
            case "Berserker":
                berserkerEnemy = true;
                break;
            case "Invisible":
                invisibleEnemy = true;
                break;
            default:
                inescapableEnemy = true;
                break;
        }
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
            puzzle1 = true;
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
        puzzle2 = true;
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
            puzzle3 = true;
            player.setUseShock();
        }
    }

    public Data getData()
    {
        Data data = new Data(this);
        return data;

    }
}


public class Data
{
    public float[] position;
    public float speed;
    public float damage;
    public float maxHearths;
    public float actualHearths;
    //public bool useShield;
    //public bool useInvocation;
    //public bool useShock;
    public bool puzzle1;
    public bool puzzle2;
    public bool puzzle3;
    public bool berserkerEnemy;
    public bool invisibleEnemy;
    public bool inescapableEnemy;

    public Data (Stats stats)
    {
        position = new float[2];
        position[0] = stats.player.transform.position.x;
        position[1] = stats.player.transform.position.y;
        speed = stats.player.speed;
        damage = stats.hitUp.damage;
        maxHearths = stats.player.hearthContainers.maxHearths;
        actualHearths = stats.player.currentHealth.RuntimeValue;
        puzzle1 = stats.puzzle1;
        puzzle2 = stats.puzzle2;
        puzzle3 = stats.puzzle3;
        berserkerEnemy = stats.berserkerEnemy;
        invisibleEnemy = stats.invisibleEnemy;
        inescapableEnemy = stats.inescapableEnemy;

    }
}