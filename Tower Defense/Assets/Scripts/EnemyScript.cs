using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int livesTaken = 1;

    private void OnDestroy()
    {
        WaveSpawner.enemiesAlive--;
    }
}
