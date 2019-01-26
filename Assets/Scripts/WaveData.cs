using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "Waves/Data", order = 1)]
public class WaveData : ScriptableObject
{

    [SerializeField]
    public Transform[] enemies;
    public float spawnInterval;
    public float timeBetweenWaves;
    private GameObject pathParent;
    private List<GameObject> path;
    private GameObject spawner;

    public IEnumerator Wave(float timeBetweenWaves, int waveCount)
    {
        pathParent = GameObject.FindGameObjectWithTag("Path");
        spawner = GameObject.FindGameObjectWithTag("EnemySpawn");

        var currentWave = 0;

        while (true)
        {
            for (var i = 0; i < spawner.GetComponent<EnemyWaves>().enemyPerWave; i++)
            {
                var enemyGO = enemies[Random.Range(0, 6)];
                var spawnedEnemy = Instantiate(enemyGO, spawner.transform.position, Quaternion.identity);
                spawnedEnemy.GetComponent<Enemy>().Parentpath = pathParent;
                spawnedEnemy.GetComponent<Enemy>().speed = 3f;
                spawner.GetComponent<EnemyWaves>().enemiesAlive++;
                yield return new WaitForSeconds(spawnInterval);
            }

            spawner.GetComponent<EnemyWaves>().enemyPerWave++;
            currentWave++;
            Debug.Log("Wave: " + currentWave + " complete.");

            if (spawner.GetComponent<EnemyWaves>().enemiesAlive == 0)
            {
                spawner.GetComponent<EnemyWaves>().WaveCompleted();
            }

            if (currentWave == waveCount)
            {
                spawner.GetComponent<EnemyWaves>().WaveCompleted();
                Debug.Log("Level complete.");
                break;
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

}
