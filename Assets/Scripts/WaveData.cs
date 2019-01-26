using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "Waves/Data", order = 1)]
public class WaveData : ScriptableObject {

    [SerializeField]
    public Transform[] enemies;
    public float spawnInterval;
    public int enemyPerWave;
    private GameObject pathParent;
    private List<GameObject> path;


    public IEnumerator Wave (float timeBetweenWaves, int waveCount)
    {
        pathParent = GameObject.FindGameObjectWithTag("Path");

        while (true)
        {
            var currentWave = 0;

            for (var i = 0; i < enemyPerWave; i++)
            {
                var enemyGO = enemies[Random.Range(0, 2)];
                var spawnedEnemy = Instantiate(enemyGO, GameObject.FindGameObjectWithTag("EnemySpawn").transform.position, Quaternion.identity);
                spawnedEnemy.GetComponent<Enemy>().Parentpath = pathParent;
                spawnedEnemy.GetComponent<Enemy>().speed = 3f;
                yield return new WaitForSeconds(spawnInterval);
            }
            enemyPerWave++;
            currentWave++;
            if (currentWave == waveCount)
            {
                break;
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
        
}
