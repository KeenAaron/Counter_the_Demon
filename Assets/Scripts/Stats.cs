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

    void Start()
    {
        if (PlayerPrefs.GetInt("continue") == 1)
        {
            loadData();
        }
    }

    public void increaseStats(string enemy)
    {
        hitUp.increaseDamage();
        hitLeft.increaseDamage();
        hitRight.increaseDamage();
        hitDown.increaseDamage();
        player.increaseSpeed();
        player.hearthContainers.setHeartContainer(1);
        player.currentHealth.setPlayerHealth(2);
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

    public void loadData()
    {
        Data data = new Data(this);
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("data"), data);
        
        player.transform.position = new Vector3(data.position[0], data.position[1], 0);
        player.speed = data.speed;
        hitUp.damage = data.damage;
        hitLeft.damage = data.damage;
        hitRight.damage = data.damage;
        hitDown.damage = data.damage;
        player.hearthContainers.setHeartContainer(data.maxHearths/2 - 3);
        player.currentHealth.setPlayerHealth(data.maxHearths - 6);
        player.currentHealth.RuntimeValue = data.actualHearths;
        puzzle1 = data.puzzle1;
        puzzle2 = data.puzzle2;
        puzzle3 = data.puzzle3;
        berserkerEnemy = data.berserkerEnemy;
        invisibleEnemy = data.invisibleEnemy;
        inescapableEnemy = data.inescapableEnemy;

        if (puzzle1)
        {
            GameObject Puzzle1 = GameObject.Find("Puzzle1");
            Destroy(Puzzle1.transform.GetChild(0).gameObject);
            Destroy(Puzzle1.transform.GetChild(1).gameObject);
            Destroy(Puzzle1.transform.GetChild(2).gameObject);

            player.setUseShield();
        }
        if (puzzle2)
        {
            GameObject Puzzle2 = GameObject.Find("Puzzle2");
            Destroy(Puzzle2.transform.GetChild(0).gameObject);
            Destroy(Puzzle2.transform.GetChild(1).gameObject);
            Destroy(Puzzle2.transform.GetChild(2).gameObject);

            player.setUseInvocation();
        }
        if (puzzle3)
        {
            GameObject Puzzle3 = GameObject.Find("Puzzle3");
            Destroy(Puzzle3.transform.GetChild(0).gameObject);
            Destroy(Puzzle3.transform.GetChild(1).gameObject);
            Destroy(Puzzle3.transform.GetChild(2).gameObject);
            Destroy(Puzzle3.transform.GetChild(3).gameObject);
            Destroy(Puzzle3.transform.GetChild(4).gameObject);
            Destroy(Puzzle3.transform.GetChild(5).gameObject);

            player.setUseShock();
        }
        if (berserkerEnemy)
        {
            Destroy(GameObject.Find("Berserker"));
        }
        if (invisibleEnemy)
        {
            Destroy(GameObject.Find("Invisible"));
        }
        if (inescapableEnemy)
        {
            Destroy(GameObject.Find("EnemyInescapable"));
        }
    }
}

public class Data
{
    public float[] position;
    public float speed;
    public float damage;
    public float maxHearths;
    public float actualHearths;
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
        maxHearths = stats.player.currentHealth.maxHearths;
        actualHearths = stats.player.currentHealth.RuntimeValue;
        puzzle1 = stats.puzzle1;
        puzzle2 = stats.puzzle2;
        puzzle3 = stats.puzzle3;
        berserkerEnemy = stats.berserkerEnemy;
        invisibleEnemy = stats.invisibleEnemy;
        inescapableEnemy = stats.inescapableEnemy;

    }
}