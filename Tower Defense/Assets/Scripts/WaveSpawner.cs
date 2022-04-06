using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive;
    public Wave[] wave;
    public Transform enemyPrefab;
    public int CurrentWave;
    private int nextWave = 0;

    private float searchCountdown = 1f;

    spawnStates state = spawnStates.ReadyToStart;

    public Transform SpawnPoint;
    bool startWave;
    [SerializeField]
    Text waveTXT;
    private void Update()
    {
        if (enemiesAlive > 0)
            return;

        if(state == spawnStates.Waiting)
        {
            if(!EnemyIsAlive())
            {
                ResetForNextWave();
            }
            else
            {
                return;
            }
        }

        if (startWave)
        {
            if (state != spawnStates.Spawning)
            {
                for (int i = 0; i < wave[nextWave].enemies.Length; i++)
                {
                    StartCoroutine(SpawnWave(wave[nextWave].enemies[i]));
                }
            }
        }

    }
    void ResetForNextWave()
    {
        startWave = false;
        state = spawnStates.ReadyToStart;
        Player.UpdateCurrency(100);
        if(nextWave +1 > wave.Length - 1)
        {
            nextWave = 0;
        }
        else
            nextWave++;
    }
    public void StartNextWave()
    {
        if (!startWave)
        {
            startWave = true;
            CurrentWave++;
            waveTXT.text = "Wave : " + CurrentWave;
        }
    }
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    void SpawnEnemy(Transform enemy)
    {
        Instantiate(enemy, SpawnPoint.position, transform.rotation);
        enemiesAlive++;
    }
    
    IEnumerator SpawnWave(EnemiesInWave _enemies)
    {
        state = spawnStates.Spawning;
        for(int i = 0;i < _enemies.amount;i++)
        {
            SpawnEnemy(_enemies.enemy);
            yield return new WaitForSeconds(1 / _enemies.spawnRate);
        }
        state = spawnStates.Waiting;
        yield break;
    }
    enum spawnStates
    {
        Spawning,
        ReadyToStart,
        Waiting
    }
    [System.Serializable]
    public class Wave
    {
        public EnemiesInWave[] enemies;
    }

    [System.Serializable]
    public class EnemiesInWave
    {
        public Transform enemy;
        public int amount;
        public float spawnRate;
    }
}
