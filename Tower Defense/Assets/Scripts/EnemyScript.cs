using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int livesTaken = 1;
    public int health = 1;
    public int moneyGained = 5;

    public void loseHealth(int amount)
    {
        health -= amount;
        if (health <= 0)
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Player.UpdateCurrency(moneyGained);
        WaveSpawner.enemiesAlive--;
    }
}
