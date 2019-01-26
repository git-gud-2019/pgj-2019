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

    private int enemiesAlive;
    private int enemiesRemaining;

    public IEnumerator Wave(int waveCount, int enemiesPerWave, float interval)
    {
        enemiesAlive = 0;
        enemiesRemaining = waveCount * enemiesPerWave;

        pathParent = GameObject.FindGameObjectWithTag("Path");
        spawner = GameObject.FindGameObjectWithTag("EnemySpawn");

        var currentWave = 0;

        for(var j = 0; j < waveCount; j++) {

            for (var i = 0; i < enemiesPerWave; i++)
            {
                var enemyGO = enemies[Random.Range(0, 6)];
                var spawnedEnemy = Instantiate(enemyGO, spawner.transform.position, Quaternion.identity);
                spawnedEnemy.GetComponent<Enemy>().Parentpath = pathParent;
                spawnedEnemy.GetComponent<Enemy>().speed = 3f;
                enemiesAlive++;
                enemiesRemaining--;
                yield return new WaitForSeconds(spawnInterval);
            }

            //spawner.GetComponent<EnemyWaves>().enemyPerWave++;

            currentWave++;
            Debug.Log("Wave: " + currentWave + " complete.");

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    public bool KillEnemy()
    {
        enemiesAlive--;
        Debug.Log("Live enemies" + enemiesAlive + " Remaining " + enemiesRemaining);
        if (enemiesAlive <= 0 && enemiesRemaining <= 0)
        {
            spawner.GetComponent<EnemyWaves>().WaveCompleted();
        }
        return false;
    }

}
